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

        public Guid FileId { get; set; }

        public File File { get; set; }
        


        public static MedicalInfo Create(IFormFile file, string createdById, Guid personId)
        {
            var result = new MedicalInfo()
            {
                CreatedById = createdById,
                PersonId = personId,
                File = new File()
                {
                    Extention = file.ContentType,
                    Name = file.FileName,
                    RealName = Guid.NewGuid().ToString(),
                    Data = file.GetBytes(),
                    CreatedById = createdById
                }                
            }; 
            return result;
        }
    }
}
