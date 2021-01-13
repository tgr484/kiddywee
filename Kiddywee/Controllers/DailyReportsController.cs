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
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
            switch (type)
            {
                case (int)EnumDailyReportType.NapsSleep: 
                    {
                        var naps = await _unitOfWork.DailyReportNaps.GetAsync(x => x.IsActive && x.PersonId == personId && x.ClassId == classId);

                        return PartialView("PartialDailyReportNap", DailyReportNap.Init(naps));
                    }
            }

            return View();
        }

        #region Naps
        [HttpGet]
        public async Task<IActionResult> GetNaps(Guid personId, Guid classId, Guid organizationId, DateTime? date)
        {
            var startDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);
            var endDate = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 59);
            
            var naps = await _unitOfWork.DailyReportNaps.GetAsync(x => x.IsActive && x.OrganizationId == _organizationId
                                                                               && x.ClassId == classId
                                                                               && x.PersonId == personId
                                                                               && x.Date >= startDate && x.Date <= endDate
                                                                              );


            return PartialView("PartialDailyReportNap", DailyReportNap.Init(naps));
        }

        [HttpGet]
        public async Task<IActionResult> AddEditNap(Guid personId, Guid classId, Guid organizationId, DateTime? date = null)
        {
            //var date2 = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day);

            var model = DailyReportNap.Init(personId, classId, organizationId, DateTime.UtcNow);
            return View(model);
        }

        public async Task<IActionResult> EditNap(Guid id)
        {
            var nap = await _unitOfWork.DailyReportNaps.GetOneAsync(x => x.IsActive && x.Id == id);
            return View("AddEditNote", DailyReportNapViewModel.Create(nap));
        }

        [HttpPost]
        public async Task<JsonResult> AddEditNap(DailyReportNapViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == null)
                {
                    var nap = DailyReportNap.Create(model.PersonId, model.ClassId, model.OrganizationId, model.Date,model.StartTime, model.EndTime, model.Note, _userId);
                    await _unitOfWork.DailyReportNaps.Insert(nap);
                }
                else
                {
                    var nap = await _unitOfWork.DailyReportNaps.GetOneAsync(x => x.IsActive && x.Id == model.Id);
                    nap.Note = model.Note;
                    nap.StartTime = model.StartTime;
                    nap.EndTime = model.EndTime;
                    _unitOfWork.DailyReportNaps.Update(nap);
                }
                var result = await _unitOfWork.SaveAsync();
                if (result.Succeeded)
                {
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Nap saved", Header = "Success", Icon = "success", AdditionalData = model });

                }
                return Json(new JsonMessage { Color = "#ff6849", Message = "Save Error", Header = "Error", Icon = "error", AdditionalData = model });

            }
            else
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Model Error", Header = "Error", Icon = "error", AdditionalData = model });
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNap(Guid id)
        {
            var nap = await _unitOfWork.DailyReportNaps.GetOneAsync(x => x.Id == id);
            nap.IsActive = false;
            _unitOfWork.DailyReportNaps.Update(nap);
            var result = await _unitOfWork.SaveAsync();
            if (result.Succeeded)
            {
                return Json(new JsonMessage { Color = "#ff6849", Message = "Nap deleted", Header = "Success", Icon = "success", AdditionalData = new { id = id } });
            }
            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error", AdditionalData = new { id = id } });

        }

        #endregion

        #region Notes

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

        public async Task<IActionResult> EditNote(Guid id)
        {
            var note = await _unitOfWork.DailyReportNotes.GetOneAsync(x => x.IsActive && x.Id == id);
            return View("AddEditNote", DailyReportNoteViewModel.Create(note));
        }

        [HttpPost]
        public async Task<JsonResult> AddEditNote(DailyReportNoteViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == null)
                {
                    var note = DailyReportNote.Create(model.PersonId, model.ClassId, model.OrganizationId, model.Date, model.Note, _userId);
                    await _unitOfWork.DailyReportNotes.Insert(note);
                }
                else
                {
                    var note = await _unitOfWork.DailyReportNotes.GetOneAsync(x => x.IsActive && x.Id == model.Id);
                    note.Note = model.Note;
                    _unitOfWork.DailyReportNotes.Update(note);
                }
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
        #endregion
    }
}
