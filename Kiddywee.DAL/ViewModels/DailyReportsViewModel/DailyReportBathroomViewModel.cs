using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportBathroomViewModel
    {
        public Guid? Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }

        public string Time { get; set; }
        public EnumBathroomDetailsType Type { get; set; }
        public string Note { get; set; }

        public static DailyReportBathroomViewModel Create(DailyReportBathroom bath)
        {
            return new DailyReportBathroomViewModel()
            {
                ClassId = bath.ClassId,
                Id = bath.Id,
                Date = bath.Date,
                Note = bath.Note,
                OrganizationId = bath.OrganizationId,
                PersonId = bath.PersonId,
                Time = bath.Time,
                Type = bath.Type
            };
        }
    }
}
