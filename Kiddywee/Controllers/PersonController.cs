﻿using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]

    public class PersonController : BaseController
    {
        public PersonController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public async Task<IActionResult> Index(Guid? id)
        {
            var people = new List<Person>();
            if (!id.HasValue)
            {
                people = await _unitOfWork.People
                    .GetAsync(p => p.OrganizationId == _organizationId, 
                    include: p => p.Include(x => x.StaffInfo)
                                   .Include(x => x.ChildInfo)
                                   .Include(x => x.PersonToClasses)
                                   .Include(x => x.Attendances));
            }
            else
            {
                people = await _unitOfWork.People.GetAsync(p => p.OrganizationId == _organizationId
                    && p.PersonToClasses.Any(x => x.ClassId == id.Value && x.IsActive),
                    include: p => p.Include(x => x.PersonToClasses)
                                   .Include(x => x.StaffInfo)
                                   .Include(x => x.ChildInfo)
                                   .Include(x => x.Attendances));
            }


            var model = Person.Init(people);
            return View(model);
        }
        #region Create
        [HttpGet]
        public async Task<IActionResult> CreateStaff()
        {
            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);
            var organizations = await _unitOfWork.Organizations.GetAsync();
            StaffCreateViewModel model = new StaffCreateViewModel() { Classes = classes, Organizations = organizations };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaff(StaffCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var person = Person.Create(model, _organizationId.Value);
                await _unitOfWork.People.Insert(person);
                var personResult = await _unitOfWork.SaveAsync();
                if (personResult.Succeeded)
                {
                    if (model.MedicalInfo != null)
                    {
                        var medicalInfo = FileInfo.Create(model.MedicalInfo, _userId, DAL.Enum.EnumFileType.MedicalInfo,person.Id);
                        await _unitOfWork.FileInfos.Insert(medicalInfo);
                    }


                    var staffInfo = StaffInfo.Create(model, _userId);
                    staffInfo.OrganizationId = _organizationId.Value;
                    await _unitOfWork.StaffInfos.Insert(staffInfo);
                    var staffInfoResult = await _unitOfWork.SaveAsync();
                    if (staffInfoResult.Succeeded)
                    {
                        person.StaffInfoId = staffInfo.Id;

                        var personToClass = PersonToClass.Create(person.Id, model.ClassId, _userId);
                        await _unitOfWork.PersonToClasses.Insert(personToClass);
                        await _unitOfWork.SaveAsync();
                    }
                }

                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateChild()
        {
            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);
            ChildCreateViewModel model = new ChildCreateViewModel() { Classes = classes };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChild(ChildCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = Person.Create(model, _organizationId.Value);
                await _unitOfWork.People.Insert(person);
                var personResult = await _unitOfWork.SaveAsync();
                if (personResult.Succeeded)
                {
                    if (model.MedicalInfo != null)
                    {
                        var medicalInfo = FileInfo.Create(model.MedicalInfo, _userId, DAL.Enum.EnumFileType.MedicalInfo,person.Id);
                        await _unitOfWork.FileInfos.Insert(medicalInfo);
                    }

                    var childInfo = ChildInfo.Create(model, _userId);
                    await _unitOfWork.ChildInfos.Insert(childInfo);

                    var childResult = await _unitOfWork.SaveAsync();
                    if (childResult.Succeeded)
                    {
                        person.ChildInfoId = childInfo.Id;
                        var personToClass = PersonToClass.Create(person.Id, model.ClassId, _userId);
                        await _unitOfWork.PersonToClasses.Insert(personToClass);

                        await _unitOfWork.SaveAsync();
                    }
                }

                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditStaff(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.StaffInfo)
                                                                                  //.Include(e => e.MedicalInfos)
                                                                                  .Include(r => r.PersonToClasses));

            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);

            var model = StaffInfo.Init(person, classes);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditStaff(StaffEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                      include: p => p.Include(w => w.StaffInfo)
                                                                                     //.Include(e => e.MedicalInfos)
                                                                                     .Include(r => r.PersonToClasses));

                person.Update(model);

                _unitOfWork.People.Update(person);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    var personToClasses = person.PersonToClasses;

                    personToClasses.ForEach(x => x.IsActive = false);
                    _unitOfWork.PersonToClasses.UpdateRange(personToClasses);
                    await _unitOfWork.PersonToClasses.Insert(PersonToClass.Create(person.Id, model.ClassId, _userId));
                    var result2 = await _unitOfWork.SaveAsync();
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditChild(Guid personId)
        {
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId,
                                                                   include: p => p.Include(w => w.ChildInfo)
                                                                                  .Include(r => r.PersonToClasses));

            var classes = await _unitOfWork.Classes.GetAsync(x => x.OrganizationId == _organizationId);

            var model = ChildInfo.Init(person, classes);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditChild(ChildEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var person = await _unitOfWork.People.GetOneAsync(x => x.Id == model.PersonId,
                                                                   include: p => p.Include(w => w.ChildInfo)
                                                                                 
                                                                                  .Include(r => r.PersonToClasses));

                person.Update(model);

                _unitOfWork.People.Update(person);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    var personToClasses = person.PersonToClasses;

                    personToClasses.ForEach(x => x.IsActive = false);
                    _unitOfWork.PersonToClasses.UpdateRange(personToClasses);
                    await _unitOfWork.PersonToClasses.Insert(PersonToClass.Create(person.Id, model.ClassId, _userId));
                    var result2 = await _unitOfWork.SaveAsync();
                }
                return Redirect(Request.Headers["Referer"].ToString());

            }
            return View(model);
        }
        #endregion
    }
}
