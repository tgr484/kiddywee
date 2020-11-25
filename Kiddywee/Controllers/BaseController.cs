using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.ClassesViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class BaseController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public string _userId = null;
        public Guid? _organizationId = null;
        public Guid? _classId = null;

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _userId = context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value; 
            if (!context.HttpContext.User.IsInRole(Constants.ROLE_GLOBALADMIN))
            {
                _organizationId = context.HttpContext.User.Identity.GetOrganizationId();
            }

            SetClasses();
            base.OnActionExecuting(context);
        }

        private void SetClasses()
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            var classes = _unitOfWork.Classes.Get(p => p.IsActive && p.OrganizationId == _organizationId.Value);
            var attendancesForToday = _unitOfWork.Attendances.Get(x => x.IsActive
                                                                        && x.InDate >= startDate
                                                                        && x.InDate <= endDate
                                                                        && x.OrganizationId == _organizationId.Value);

            var persons = _unitOfWork.People.Get(p => p.OrganizationId == _organizationId,
                include: p => p.Include(x => x.StaffInfo).Include(x => x.ChildInfo).Include(p => p.PersonToClasses));


            var attendanceToSchool = attendancesForToday.Where(x => x.ClassId == null);
            int childrenInsideSchool = 0;
            int staffInsideSchool = 0;

            foreach (var p in persons)
            {
                var attendanceForPerson = attendanceToSchool.FirstOrDefault(x => x.PersonId == p.Id);
                if (attendanceForPerson != null)
                {
                    if (attendanceForPerson.OutDate.HasValue == false)
                    {
                        if (p.ChildInfo != null)
                        {
                            ++childrenInsideSchool;
                        }
                        if (p.StaffInfo != null)
                        {
                            ++staffInsideSchool;
                        }
                    }
                }
            }
            var staffInOrganization = persons.Where(x => x.StaffInfo != null);
            var childrenInOrganization = persons.Where(x => x.ChildInfo != null);
            ViewBag.Classes = new List<ClassViewModel>();
            var classesWithoutAll = Class.Init(classes, attendancesForToday, persons);
            if(classesWithoutAll.Any())
            {
                ViewBag.Classes.Add(new ClassViewModel()
                {
                    ClassId = "0",
                    StaffIn = staffInsideSchool,
                    StaffTotal = staffInOrganization.Count(),
                    ChildrenIn = childrenInsideSchool,
                    ChildrenTotal = childrenInOrganization.Count(),
                    ClassName = "All"
                });
                ViewBag.Classes.AddRange(classesWithoutAll);
            }
        }
    }
}
