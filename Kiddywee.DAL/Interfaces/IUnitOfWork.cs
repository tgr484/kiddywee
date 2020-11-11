using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Person> People { get; }
        IGenericRepository<Contact> Contacts { get; }

        void Save();
        Task<IdentityResult> SaveAsync();
    }
}
