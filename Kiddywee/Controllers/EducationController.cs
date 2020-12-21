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

        public async Task<JsonResult> LessonPlansJson(Guid? classId)
        {
            var lessonPlansForClass = await _unitOfWork.LessonPlans.GetAsync(x => x.IsActive && x.ClassId == classId);
            var result = LessonPlan.ToJson(lessonPlansForClass);
            var weeklyLessonPlan = await _unitOfWork.LessonPlanWeaklies.GetAsync(x => x.IsActive && x.ClassId == classId);
            result.AddRange(LessonPlanWeakly.ToJson(weeklyLessonPlan));
            return Json(result);
        }

        [HttpGet]
        public async Task<IActionResult> EditLessonPlan(Guid? classId, DateTime? date)
        {
            var lessonPlan = await _unitOfWork.LessonPlans.GetOneAsync(x => x.IsActive && x.ClassId == classId && x.Date == date);
            var model = new LessonPlanViewModel();
            if (lessonPlan != null)
            {
                model = LessonPlan.Init(lessonPlan);
            }
            else
            {
                model.Date = date.Value;
            }
            var sundayDateOfWeek = model.Date.AddDays(7 - (int)model.Date.DayOfWeek);
            LessonPlanWeakly weeklyLessonPlan = await _unitOfWork.LessonPlanWeaklies.GetOneAsync(x => x.IsActive
                                                                                        && x.ClassId == classId
                                                                                        && x.WeekDateSunday == sundayDateOfWeek);
            if (weeklyLessonPlan != null)
            {
                model.WeeklyTheme = weeklyLessonPlan.Theme;
                model.LessonPlanWeeklyId = weeklyLessonPlan.Id;
            }

            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> EditLessonPlan(LessonPlanViewModel model)
        {
            //Update weekly theme
            var sundayDateOfWeek = model.Date.AddDays(7 - (int)model.Date.DayOfWeek);
            LessonPlanWeakly weeklyLessonPlan = await _unitOfWork.LessonPlanWeaklies.GetOneAsync(x => x.IsActive && x.Id == model.LessonPlanWeeklyId);
            if (weeklyLessonPlan != null)
            {
                weeklyLessonPlan.Theme = model.WeeklyTheme;
                _unitOfWork.LessonPlanWeaklies.Update(weeklyLessonPlan);
            }
            else
            {
                if (String.IsNullOrEmpty(model.WeeklyTheme) == false)
                {
                    weeklyLessonPlan = LessonPlanWeakly.Create(model, sundayDateOfWeek, _userId);
                    await _unitOfWork.LessonPlanWeaklies.Insert(weeklyLessonPlan);
                }
            }
            //Update daily theme
            if (model.LessonPlanId == null)
            {
                if (String.IsNullOrEmpty(model.Theme) == false)
                {
                    var lessonPlan = LessonPlan.Create(model, _userId);
                    await _unitOfWork.LessonPlans.Insert(lessonPlan);
                }

            }
            else
            {
                var lessonPlan = await _unitOfWork.LessonPlans.GetOneAsync(x => x.IsActive && x.Id == model.LessonPlanId);
                lessonPlan.Update(model);
                _unitOfWork.LessonPlans.Update(lessonPlan);
            }
            var result = await _unitOfWork.SaveAsync();
            if (result.Succeeded)
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Lesson plan saved", Header = "Success", Icon = "success", AdditionalData = model });

            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Success", Icon = "error", AdditionalData = model });
        }
    }
}
