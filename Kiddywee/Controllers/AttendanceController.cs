using Kiddywee.BLL.Core;
using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
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
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            var inAttendance = await _unitOfWork.Attendances.GetOneAsync(x => x.IsActive && x.InDate >= startDate && x.InDate <= endDate);
            //Checkout
            if(inAttendance != null)
            {
                if(inAttendance.OutDate.HasValue)
                {
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Person already checked out", Header = "Error", Icon = "success" });
                }
                else
                {
                    inAttendance.OutDate = DateTime.UtcNow;
                    _unitOfWork.Attendances.Update(inAttendance);                    
                    var result = await _unitOfWork.SaveAsync();
                    if (result.Succeeded)
                    {
                        return Json(new JsonMessage { Color = "#ff6849", Message = "Person checked out", Header = "Success", Icon = "success" });
                    }
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error" });
                }
            }
            //Checkin
            else
            {
                var attendance = Attendance.Create(personId, classId, _organizationId, _userId);
                await _unitOfWork.Attendances.Insert(attendance);
                var result = await _unitOfWork.SaveAsync();

                if (result.Succeeded)
                {
                    return Json(new JsonMessage { Color = "#ff6849", Message = "Person checked in", Header = "Success", Icon = "success" });
                }

                return Json(new JsonMessage { Color = "#ff6849", Message = "Error", Header = "Error", Icon = "error" });
            }            
        }
    }
}
