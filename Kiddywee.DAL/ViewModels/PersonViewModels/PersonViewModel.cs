﻿using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class PersonViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ClassId { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string CheckInOutIcon
        {
            get 
            {
                return IsIn ? "<i class='sl-icon-logout'></i>" : "<i class='sl-icon-login'></i>";
            }
        }
        public bool IsIn { get; set; }
        public string AttendanceCssClass
        {
            get
            {
                return IsIn ? "person-in" : "person-out";
            }
        }

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
        public Guid Id { get; set; }

        public StaffInfo StaffInfo { get; set; }
        public ChildInfo ChildInfo { get; set; }

        public string CardBorderColor 
        { 
            get {                
                if (this.StaffInfo != null)
                {
                    return "#1144AA";
                }
                else
                {
                    return "#FFA700";
                }
            }
            set { } 
        }
    }
}
