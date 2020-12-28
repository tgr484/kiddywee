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
            var person = await _unitOfWork.People.GetOneAsync(x => x.Id == personId);
            var @class = await _unitOfWork.Classes.GetOneAsync(x => x.Id == classId);
            return View(DailyReportViewModel.Create(personId, classId, person?.FullName, @class.DailyReportTypes));
        }
    }
}
