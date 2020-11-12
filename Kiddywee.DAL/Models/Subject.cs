﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Subject : BaseEntity
    {        
        public string Name { get; set; }
        public Guid? OrgnizationId { get; set; }
        public Organization Orgnization { get; set; }

        public Guid? ClassId { get; set; }

        public Class Class { get; set; }

        
    }
}
