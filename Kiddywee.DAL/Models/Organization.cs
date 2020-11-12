using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class Organization : BaseEntity
    {
        public Organization()
        {
            Classes = new List<Class>();
            Subjects = new List<Subject>();
        }

        public string Name { get; set; }

        public List<Class> Classes { get; set; }
        public List<Subject> Subjects { get; set; }
        
    }
}
