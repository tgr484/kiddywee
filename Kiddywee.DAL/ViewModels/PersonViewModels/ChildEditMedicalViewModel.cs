using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildEditMedicalViewModel
    {
        public DateTime? NextMedical { get; set; }
        public bool Allergies { get; set; }
        public string AllergiesNotes { get; set; }

        public Guid PersonId { get; set; }
    }
}
