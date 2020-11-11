using Kiddywee.DAL.Data;
using Kiddywee.DAL.Interfaces;
using Kiddywee.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kiddywee.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationDbContext _context;

        private IGenericRepository<Person> _peopleRepository;
        private IGenericRepository<Contact> _contactsRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Person> People => _peopleRepository ??= new GenericRepository<Person>(_context);
        public IGenericRepository<Contact> Contacts => _contactsRepository ??= new GenericRepository<Contact>(_context);

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<IdentityResult> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (Exception e)
            {
                return IdentityResult.Failed(new IdentityError() { Code = "Error", Description = e.Message });
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
