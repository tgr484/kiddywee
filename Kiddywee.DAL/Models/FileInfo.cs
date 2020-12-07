using Kiddywee.DAL.Enum;
using Kiddywee.DAL.Extensions;
using Kiddywee.DAL.ViewModels.PersonViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text; 

namespace Kiddywee.DAL.Models
{
    public class FileInfo  
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;

        public string CreatedById { get; set; } = String.Empty;
         
        public string Name { get; set; }
        public string Extention { get; set; }
        public string RealName { get; set; }
        public byte[] Data { get; set; }
        public Guid? PersonId { get; set; }
        public Guid? OrganizationId { get; set; }
        public Guid? ClassId { get; set; }

        public EnumFileType FileType { get; set; }

        public static FileInfo Create(IFormFile file, string createdById, EnumFileType fileType, Guid? personId = null, Guid? organizationId = null, Guid? classId = null)
        {
            var result = new FileInfo()
            {
                CreatedById = createdById,
                PersonId = personId,    
                ClassId = classId,
                OrganizationId = organizationId,
                Extention = file.ContentType,
                Name = file.FileName,
                RealName = Guid.NewGuid().ToString(),
                Data = file.GetBytes(),
                FileType = fileType
            };
            return result;
        }

        public static List<PersonEditFileViewModel> Init(List<FileInfo> files)
        {
            var result = new List<PersonEditFileViewModel>();
            foreach(var file in files)
            {
                result.Add(new PersonEditFileViewModel() { FileId = file.Id, Name = file.Name});
            }
            return result;
        }
    }
}
