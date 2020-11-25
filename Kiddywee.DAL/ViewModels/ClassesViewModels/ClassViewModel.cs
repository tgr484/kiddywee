using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.ClassesViewModels
{
    public class ClassViewModel
    {
        public string BackgroundColorCss
        {
            get
            {
                return ClassName == "All" ? "class-all" : "class-class";
            }
        }
        
        public string ClassName { get; set; } 
        public string ShortClassName
        {
            get
            {
                if (ClassName.Length > 10)
                {
                    string result = ClassName.Substring(0, 8);
                    result = String.Concat(result, "...");
                    return result;
                }
                else
                {
                    return ClassName;
                }
            }
            set { }

        }
        public int ChildrenIn { get; set; }

        public int ChildrenTotal { get; set; }
        public int StaffIn { get; set; }

        public int StaffTotal { get; set; }
        public string ClassId { get; set; }
    }
}
