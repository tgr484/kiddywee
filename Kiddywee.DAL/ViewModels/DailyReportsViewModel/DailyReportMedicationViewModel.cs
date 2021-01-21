using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportMedicationViewModel
    {
        public Guid? Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Medication { get; set; }
        public EnumMedicationValueType Type { get; set; }

        public string Time { get; set; }

        public string Amount { get; set; }
        public static DailyReportMedicationViewModel Create(DailyReportMedication medication)
        {
            return new DailyReportMedicationViewModel()
            {
                ClassId = medication.ClassId,
                Id = medication.Id,
                Date = medication.Date,
                Medication = medication.Medication,
                OrganizationId = medication.OrganizationId,
                PersonId = medication.PersonId,
                Amount = medication.Amount,
                Time = medication.Time,
                Type = medication.Type
            };
        }
    }
}
