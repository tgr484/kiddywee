using Kiddywee.BLL.Core;
using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiddywee.Controllers
{
    [Authorize]

    public class AttendanceController : BaseController
    {
        public AttendanceController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task<IActionResult> Index(Guid? classId, DateTime? date)
        //{
        //    DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); ;
        //    DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); ;
        //    if (date.HasValue)
        //    {
        //        startDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
        //        endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
        //    }

        //    List<Attendance> attendancesForDay = new List<Attendance>();
        //    if(classId.HasValue)
        //    {
        //        attendancesForDay = await _unitOfWork.Attendances.GetAsync(x => x.IsActive
        //                                                                && x.InDate >= startDate
        //                                                                && x.InDate <= endDate
        //                                                                && x.ClassId == classId.Value
        //                                                                && x.OrganizationId == _organizationId.Value, include: x => x.Include(p => p.Person));
        //    }
        //    else
        //    {
        //        attendancesForDay = await _unitOfWork.Attendances.GetAsync(x => x.IsActive
        //                                                                && x.InDate >= startDate
        //                                                                && x.InDate <= endDate
        //                                                                && x.ClassId == null
        //                                                                && x.OrganizationId == _organizationId.Value, include: x => x.Include(p => p.Person));
        //    }
                
        //    var model = Attendance.Init(attendancesForDay);





        //    return PartialView("_PartialAttendance",model);
        //}

        public async Task<JsonResult> GetAttendanceAjax(Guid? classId, DateTime? date)
        {
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); ;
            DateTime endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59); ;
            if (date.HasValue)
            {
                startDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day);
                endDate = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, 23, 59, 59);
            }

            List<Attendance> attendancesForDay = new List<Attendance>();
            if (classId.HasValue)
            {
                attendancesForDay = await _unitOfWork.Attendances.GetAsync(x => x.IsActive
                                                                        && x.InDate >= startDate
                                                                        && x.InDate <= endDate
                                                                        && x.ClassId == classId.Value
                                                                        && x.OrganizationId == _organizationId.Value, include: x => x.Include(p => p.Person));
            }
            else
            {
                attendancesForDay = await _unitOfWork.Attendances.GetAsync(x => x.IsActive
                                                                        && x.InDate >= startDate
                                                                        && x.InDate <= endDate
                                                                        && x.ClassId == null
                                                                        && x.OrganizationId == _organizationId.Value, include: x => x.Include(p => p.Person));
            }

            var model = Attendance.Init(attendancesForDay);

            var result = new List<object>();
            foreach (var a in model)
            {
                result.Add(new { a.Name, InDate = a.InDate.ToString("H:mm:ss"), OutDate = a.OutDate?.ToString("H:mm:ss"), a.Hours, attendanceId = a.AttendanceId.ToString()});
            }
            return Json(result);
        }

        public async Task<JsonResult> CheckInOut(Guid personId, Guid? classId)
        {
            var startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var endDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);


            var inAttendance = await _unitOfWork.Attendances.GetOneAsync(x => x.IsActive && x.PersonId == personId && x.ClassId == classId && x.InDate >= startDate && x.InDate <= endDate);
            //Checkout
            if(inAttendance != null)
            {
                if(inAttendance.OutDate.HasValue)
                {                    
                    return Json(new JsonMessage { Color = "#ff0000", Message = "Person already checked out", Header = "Error", Icon = "error" });
                }
                else
                {
                    inAttendance.OutDate = DateTime.UtcNow;
                    _unitOfWork.Attendances.Update(inAttendance);                    
                    var result = await _unitOfWork.SaveAsync();
                    if (result.Succeeded)
                    {
                        return Json(new JsonMessage { Color = "#ff6849", Message = "Person checked out", Header = "Success", Icon = "success", AdditionalData = new {id = personId } });
                    }
                    return Json(new JsonMessage { Color = "#ff0000", Message = "Error", Header = "Error", Icon = "error" });
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

                return Json(new JsonMessage { Color = "#ff0000", Message = "Error", Header = "Error", Icon = "error" });
            }            
        }
    }
}
