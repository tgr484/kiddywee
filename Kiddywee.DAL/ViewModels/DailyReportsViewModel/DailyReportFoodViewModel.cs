using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportFoodViewModel
    {
        public Guid? Id { get; set; }        

        public string Food { get; set; }
        public EnumFoodType FoodType { get; set; }
        //public static DailyReportFoodViewModel Create(DailyReportNote note)
        //{
        //    return new DailyReportFoodViewModel()
        //    {
        //        ClassId = note.ClassId,
        //        Id = note.Id,
        //        Date = note.Date,
        //        Note = note.Note,
        //        OrganizationId = note.OrganizationId,
        //        PersonId = note.PersonId
        //    };
        //}
    }
}
