using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class DailyReportsController : BaseController
    {
        public DailyReportsController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            ViewBag.Page = "DailyReports";
            return View();
        }

        public async Task<IActionResult> DailyReport(Guid personId, Guid classId)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId);
            var @class = await _unitOfWork.Classes.GetOneAsync(x => x.Id == classId);
            var dailyReports = await _unitOfWork.DailyReports.GetAsync(x => x.OrganizationId == _organizationId
                                                                            && x.ClassId == classId
                                                                            && x.PersonId == personId
                                                                            && x.Date == date
                                                                            && x.Class.DailyReportTypes.Contains(x.Type));
            
            return View(DailyReportViewModel.Create(personId, classId, person?.FullName, @class.DailyReportTypes, dailyReports));
        }
    }
}
