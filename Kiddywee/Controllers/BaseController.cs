using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
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

            ViewBag.Classes = Class.Init(classes, attendancesForToday, persons);
        }
    }
}
