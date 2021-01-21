using Kiddywee.DAL.Enum;
using Kiddywee.DAL.ViewModels.DailyReportsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiddywee.DAL.Models
{
    public class DailyReportMedication : BaseEntity
    {
        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public Class Class { get; set; }
        public Guid ClassId { get; set; }

        public Organization Organization { get; set; }
        public Guid OrganizationId { get; set; }

        public string Medication { get; set; }

        public EnumMedicationValueType Type {get;set;}

        public string Time { get; set; }

        public string Amount { get; set; }

        public DateTime Date { get; set; }

        public static DailyReportMedication Create(Guid personId, 
                                         Guid classId, 
                                         Guid organizationId, 
                                         DateTime date, 
                                         string medication,
                                         string time,
                                         string amount,
                                         EnumMedicationValueType type,
                                         string createdBy)
        {
            return new DailyReportMedication() 
            { 
                PersonId = personId,
                ClassId = classId,
                OrganizationId = organizationId,
                Date = date,
                Medication = medication,
                Amount = amount,
                Type = type,
                Time = time,
                CreatedById = createdBy
            };
        }

        public static DailyReportMedicationViewModel Init(Guid personId,
                                         Guid classId,
                                         Guid organizationId,
                                         DateTime date
                                         )
        {
            return new DailyReportMedicationViewModel()
            {
                ClassId = classId,
                Date = date,
                OrganizationId = organizationId,
                PersonId = personId
            };
        }

        public static List<DailyReportMedicationViewModel> Init(List<DailyReportMedication> medications)
        {
            return medications.Select(x => new DailyReportMedicationViewModel() {
                ClassId = x.ClassId, 
                Date = x.Date, 
                Id = x.Id,
                Medication = x.Medication, 
                OrganizationId = x.OrganizationId, 
                PersonId = x.PersonId, 
                Amount = x.Amount, 
                Time = x.Time, 
                Type = x.Type }).ToList();
        }

        public void Update(DailyReportMedicationViewModel model)
        {
            this.Date = model.Date; 
            this.Medication = model.Medication; 
            this.OrganizationId = model.OrganizationId; 
            this.PersonId = model.PersonId; 
            this.Amount = model.Amount; 
            this.Time = model.Time;
            this.Type = model.Type;
        }
    }
}
