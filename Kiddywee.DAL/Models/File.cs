using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kiddywee.DAL.Models
{
    [Table("Files", Schema = "files")]
    public class File 
    {
        public string Name { get; set; }
        public string Extention { get; set; }
        public string RealName { get; set; }
        public byte[] Data { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateOfCreation { get; set; } = DateTime.UtcNow;

        public string CreatedById { get; set; } = String.Empty;
    }
}
