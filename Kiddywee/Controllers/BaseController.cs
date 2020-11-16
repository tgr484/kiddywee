using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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

        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewBag.Classes = Class.Init(_unitOfWork.Classes.Get());
            _userId = context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier).Value;


            base.OnActionExecuting(context);
        }

        
    }
}
