using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Entities;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        // INITIAL DATABASE
        private AppEFContext _context;
        // INITIAL REPOSITORIES
        private IRepository<ApplicationUser> _userRepository;
        public UnitOfWork(AppEFContext context) { _context = context; } // CTOR
        // GET FOR REPOSITORY
        public IRepository<ApplicationUser> UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new Repository<ApplicationUser>(_context);
                return _userRepository;
            }
        }
        // REALISE Save();
        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
        // DISPOSING
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
