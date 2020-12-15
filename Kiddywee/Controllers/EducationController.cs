using Kiddywee.BLL.Core;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.EducationViewModels;
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

        public async Task<JsonResult> LessonPlanCollection(Guid? classId)
        {
            ViewBag.Cls = classId;
            return Json(new JsonMessage());
        }

        [HttpPost]
        public async Task<IActionResult> EditLessonPlan (LessonPlanViewModel model)
        {
            if(model.LessonPlanId == null)
            {
                var lessonPlan = LessonPlan.Create(model, _userId);
                await _unitOfWork.LessonPlans.Insert(lessonPlan);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                var lessonPlan = await _unitOfWork.LessonPlans.GetOneAsync(x => x.IsActive && x.Id == model.LessonPlanId);
                lessonPlan.Update(model);
                _unitOfWork.LessonPlans.Update(lessonPlan);
                await _unitOfWork.SaveAsync();
            }
            return View(model);
        }

        public async Task<IActionResult> EditLessonPlan(Guid? classId, DateTime? date)
        {
            var lessonPlan = await _unitOfWork.LessonPlans.GetOneAsync(x => x.IsActive && x.ClassId == classId && x.Date == date);
            var model = new LessonPlanViewModel();
            if (lessonPlan != null)
            {
                model = LessonPlan.Init(lessonPlan);
            }
            model.Date = date.Value;
            return View(model);
        }
    }
}
