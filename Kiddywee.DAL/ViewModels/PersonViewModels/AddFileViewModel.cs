using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kiddywee.DAL.ViewModels.PersonViewModels
{
    public class AddFileViewModel
    {
        public string Description { get; set; }
        public IFormFileWrapper FileWrapper { get; set; }
    }

    public class IFormFileWrapper
    {
        public IFormFile File { get; set; }
    }
}
