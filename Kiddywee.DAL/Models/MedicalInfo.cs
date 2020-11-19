using Kiddywee.DAL.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text; 

namespace Kiddywee.DAL.Models
{
    public class MedicalInfo : BaseEntity
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string FileRealName { get; set; }
        public byte[] FileData { get; set; }


        public static MedicalInfo Create(IFormFile file, string createdById, Guid personId)
        {
            var result = new MedicalInfo()
            {
                CreatedById = createdById,
                PersonId = personId,
                FileRealName = file.FileName,
                FileExtention = file.ContentType,
                FileName = Guid.NewGuid().ToString(),
                FileData = file.GetBytes()
            }; 
            return result;
        }
    }
}
