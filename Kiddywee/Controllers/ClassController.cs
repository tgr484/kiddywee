using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.ClassesViewModels;
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
    public class ClassController : BaseController
    {
        public ClassController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string SelectClass(Guid classId)
        {
            _classId = classId;
            return _classId.ToString();
        }

        public IActionResult Create(string id)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ClassCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @class = Class.Create(model, _userId);
                await _unitOfWork.Classes.Insert(@class);
                await _unitOfWork.SaveAsync();
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var @class = await _unitOfWork.Classes.GetOneAsync(x => x.IsActive && x.Id == id);
            var allClassesExeptSelected = await _unitOfWork.Classes.GetAsync(x => x.IsActive && x.Id != id);
            var model = Class.Init(@class, allClassesExeptSelected);
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ClassEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var @class = await _unitOfWork.Classes.GetOneAsync(x => x.Id == model.ClassId);
                if (model.IsMove && model.MoveClassId.HasValue)
                {
                    //Удаление классов

                    //if (model.IsActive)
                    //{
                    //    @class.IsActive = false;
                    //}
                    var personToClasses = await _unitOfWork.PersonToClasses.GetAsync(x => x.IsActive && x.ClassId == model.ClassId);
                    personToClasses.ForEach(x => x.IsActive = false);
                    var newPersonToClasses = new List<PersonToClass>();
                    foreach (var item in personToClasses)
                    {
                        newPersonToClasses.Add(PersonToClass.Create(item.PersonId, model.MoveClassId.Value, _userId));
                    }
                    _unitOfWork.PersonToClasses.UpdateRange(personToClasses);
                    await _unitOfWork.PersonToClasses.InsertRange(newPersonToClasses);
                    var result = await _unitOfWork.SaveAsync();

                }
                else
                {
                    @class.Update(model);
                    _unitOfWork.Classes.Update(@class);
                    await _unitOfWork.SaveAsync();
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }
            return View(model);
        }


        public async Task<JsonResult> InitClasses()
        {
            var result = new List<ClassViewModel>();
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            var classes = await _unitOfWork.Classes.GetAsync(p => p.IsActive && p.OrganizationId == _organizationId.Value);
            var attendancesForToday = _unitOfWork.Attendances.Get(x => x.IsActive
                                                                        && x.InDate >= startDate
                                                                        && x.InDate <= endDate
                                                                        && x.OrganizationId == _organizationId.Value);

            var persons = _unitOfWork.People.Get(p => p.OrganizationId == _organizationId,
                include: p => p.Include(x => x.StaffInfo).Include(x => x.ChildInfo).Include(p => p.PersonToClasses));

            var staffInOrganization = persons.Where(x => x.StaffInfo != null);
            var childrenInOrganization = persons.Where(x => x.ChildInfo != null);
            result = Class.Init(classes, attendancesForToday, persons);            

            var jsonresult = result.Select(p => new
            {
                ClassId = p.ClassId.ToString(),
                StaffIn = p.StaffIn,
                StaffTotal = p.StaffTotal,
                ChildrenIn = p.ChildrenIn,
                ChildrenTotal = p.ChildrenTotal
            }).ToList();

            jsonresult.Add(new
            {
                ClassId = "0",
                StaffIn = result.Sum(p => p.StaffIn),
                StaffTotal = result.Sum(p => p.StaffTotal),
                ChildrenIn = result.Sum(p => p.ChildrenIn),
                ChildrenTotal = result.Sum(p => p.ChildrenTotal)
            }); ;
            return Json(jsonresult.OrderBy(p => p.ClassId).ToList());
        }
    }
}
