using Kiddywee.BLL.Core;
using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    public class AttendanceController : BaseController
    {
        public AttendanceController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index(Guid? classId)
        {
            return View();
        }

        public async Task<JsonResult> CheckInOut(Guid personId, Guid classId)
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);


            var attendanceExist = _unitOfWork.Attendances.
                    Get(p => p.ClassId == classId && p.PersonId == personId
                        && (p.Date >= startDate && p.Date <= DateTime.UtcNow), 
                        orderBy: p=>p.OrderByDescending(x=>x.DateOfCreation)).FirstOrDefault();

            var attendanceType = EnumAttendanceType.In;
            if (attendanceExist != null)
            {
                attendanceType = attendanceExist.AttendanceType == EnumAttendanceType.In 
                    ? EnumAttendanceType.Out : EnumAttendanceType.In; 
            } 

            var attendance = Attendance.Create(personId, classId, _organizationId, attendanceType, _userId);
            await _unitOfWork.Attendances.Insert(attendance);
            var result =  await _unitOfWork.SaveAsync();

            if (result.Succeeded)
            {
                return Json(new JsonMessage {  Color = "#ff6849", Message = "Success", Header = "Success", Icon = "success" });
            }

            return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error" });
        }
    }
}
