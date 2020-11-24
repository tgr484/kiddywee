using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class PersonViewModel
    {
        public Guid Id { get; set; }

        public StaffInfo StaffInfo { get; set; }
        public ChildInfo ChildInfo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ClassId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public string AttendanceCssClass
        {
            get
            {
                if(CheckInTime.HasValue && CheckOutTime.HasValue)
                {
                    return "person-was";
                }
                return (CheckInTime.HasValue && !CheckOutTime.HasValue) ? "person-in" : "person-out";
            }
        }
        public string CheckInOutIcon
        {
            get 
            {
                return (CheckInTime.HasValue && !CheckOutTime.HasValue) ? "<i class='sl-icon-logout'></i>" : "<i class='sl-icon-login'></i>";
            }
        }
        //public bool IsIn { get; set; }
        

        public string EditAction
        {
            get
            {
                return StaffInfo != null ? "EditStaff" : "EditChild";
            }
        }
        public string NormalizedDateOfBirth 
        { 
            get{ 
                return DateOfBirth.HasValue ? DateOfBirth?.ToString("dd MMMM yyyy") : "<br/>";
            }
                
             
            set { } 
        }
       

        public string PersonRoleCssClass 
        { 
            get {                
                if (this.StaffInfo != null)
                {
                    return "person-staff";
                }
                else
                {
                    return "person-child";
                }
            }
            set { } 
        }
    }
}
