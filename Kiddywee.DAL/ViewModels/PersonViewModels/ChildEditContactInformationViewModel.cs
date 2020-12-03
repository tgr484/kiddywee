using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class ChildEditContactInformationViewModel
    {
        public ChildEditContactInformationViewModel()
        {
            Contacts = new List<ChildContactViewModel>();
        }

        public Guid ChildId { get; set; }

        public List<ChildContactViewModel> Contacts { get; set; }
    }
}
