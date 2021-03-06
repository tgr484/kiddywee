﻿using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildEditGeneralViewModel
    {
        public ChildEditGeneralViewModel()
        {
           
        }
        public Guid PersonId { get; set; }

        public string Address { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FullName => FirstName + " " + LastName;

        public string NormalizedDateOfBirth
        {
            get
            {
                return DateOfBirth.HasValue ? DateOfBirth?.ToString("dd MMMM yyyy") : "";
            }
        }
    }
}
