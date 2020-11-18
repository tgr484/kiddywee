using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
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
                    .GetAsync(p => p.OrganizationId == _organizationId, include:p=>p.Include(x=>x.StaffInfo).Include(x=>x.ChildInfo));
            }
            else
            {
                people = await _unitOfWork.People.GetAsync(p => p.OrganizationId == _organizationId 
                    && p.PersonToClasses.Any(x => x.ClassId == id.Value),
                    include: p => p.Include(x => x.PersonToClasses)
                                   .Include(x => x.StaffInfo)
                                   .Include(x => x.ChildInfo));       
            }


            var model = Person.Init(people);
            return View(model);
        }

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
    }
}
