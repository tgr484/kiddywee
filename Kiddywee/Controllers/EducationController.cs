using Kiddywee.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class EducationController : BaseController
    {
        public EducationController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            ViewBag.Page = "Education";
            return View();
        }

        public async Task<IActionResult> LessonPlan(Guid? classId)
        {
            ViewBag.Cls = classId;
            return View();
        }

    }
}
