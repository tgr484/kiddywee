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
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Kiddywee.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork, ICompositeViewEngine viewEngine) : base(unitOfWork, viewEngine)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;            
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Page = "Attendance";
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
