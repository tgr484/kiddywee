using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Kiddywee.Models;
using Kiddywee.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kiddywee.DAL.ViewModels.AttendanceViewModels;
using Kiddywee.DAL.Models;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            
        }

        public async Task<IActionResult> Index(DateTime? date)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); ;
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); ;
            if (date.HasValue)
            {
                startDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
                endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
            }
            
            var attendancesForDay = 
                await _unitOfWork.Attendances.GetAsync(x => x.IsActive
                                                                        && x.InDate >= startDate
                                                                        && x.InDate <= endDate
                                                                        && x.OrganizationId == _organizationId.Value, include: x=> x.Include(p=> p.Person));
            var model = Attendance.Init(attendancesForDay);
            




            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
