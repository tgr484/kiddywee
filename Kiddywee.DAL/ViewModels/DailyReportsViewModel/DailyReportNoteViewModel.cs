using Kiddywee.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.ViewModels.DailyReportsViewModel
{
    public class DailyReportNoteViewModel
    {
        public Guid? Id { get; set; }

        public DateTime Date { get; set; }
        public Guid PersonId { get; set; }
        public Guid ClassId { get; set; }
        public Guid OrganizationId { get; set; }
        public string Note { get; set; }

        public static DailyReportNoteViewModel Create(DailyReportNote note)
        {
            return new DailyReportNoteViewModel()
            {
                ClassId = note.ClassId,
                Id = note.Id,
                Date = note.Date,
                Note = note.Note,
                OrganizationId = note.OrganizationId,
                PersonId = note.PersonId
            };
        }
    }
}
