using Kiddywee.BLL.Core;
using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class DailyReportsController : BaseController
    {
        private ICompositeViewEngine _viewEngine;

        public DailyReportsController(IUnitOfWork unitOfWork, ICompositeViewEngine viewEngine) : base(unitOfWork, viewEngine)
        {
            _unitOfWork = unitOfWork;
            _viewEngine = viewEngine;
        }

        public IActionResult Index()
        {
            ViewBag.Page = "DailyReports";
            return View();
        }

        public async Task<IActionResult> DailyReport(Guid personId, Guid classId)
        {
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);

            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId);
            var @class = await _unitOfWork.Classes.GetOneAsync(x => x.Id == classId);
            var dailyReports = await _unitOfWork.DailyReportNotes.GetAsync(x => x.IsActive && x.OrganizationId == _organizationId
                                                                            && x.ClassId == classId
                                                                            && x.PersonId == personId
                                                                            && x.Date >= startDate && x.Date <= endDate
                                                                           );

            return View(DailyReportViewModel.Create(personId, classId, _organizationId.Value, person?.FullName, @class.DailyReportTypes, dailyReports));
        }

        public async Task<IActionResult> GetReportsByType(Guid personId, Guid classId, int type, DateTime? date = null)
        {
            //switch (type)
            //{
            //    case (int)EnumDailyReportType.Notes: { break; }
            //}

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetNotes(Guid personId, Guid classId, Guid organizationId, DateTime? date)
        {
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
            var dailyReports = await _unitOfWork.DailyReportNotes.GetAsync(x => x.IsActive && x.OrganizationId == _organizationId
                                                                               && x.ClassId == classId
                                                                               && x.PersonId == personId
                                                                               && x.Date >= startDate && x.Date <= endDate
                                                                              );
            var model = dailyReports?.Select(x => new DailyReportNoteViewModel() { ClassId = x.ClassId, Date = x.Date, Id = x.Id, Note = x.Note, OrganizationId = x.OrganizationId, PersonId = x.PersonId }).ToList();


            return PartialView("PartialDailyReportNote", model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditNote(Guid personId, Guid classId, Guid organizationId, DateTime? date = null)
        {
            //var date2 = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);

            var model = DailyReportNote.Init(personId, classId, organizationId, DateTime.UtcNow);
            return View(model);
        }

        [HttpPost]
        public async Task<JsonResult> AddEditNote(DailyReportNoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var note = DailyReportNote.Create(model.PersonId, model.ClassId, model.OrganizationId, model.Date, model.Note, _userId);
                await _unitOfWork.DailyReportNotes.Insert(note);
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Note saved", Header = "Success", Icon = "success", AdditionalData = model });

                }
                return Json(new JsonMessage { Color = "#ff6849", Message = "Save Error", Header = "Error", Icon = "error", AdditionalData = model });

            }
            else
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Model Error", Header = "Error", Icon = "error", AdditionalData = model });
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNote(Guid id)
        {
            var note = await _unitOfWork.DailyReportNotes.GetOneAsync(x => x.Id == id);
            note.IsActive = false;
            _unitOfWork.DailyReportNotes.Update(note);
            var result = await _unitOfWork.SaveAsync();
            if (result.Succeeded)
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Note deleted", Header = "Success", Icon = "success", AdditionalData = new { id = id } });
            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = new { id = id } });

        }
    }
}
