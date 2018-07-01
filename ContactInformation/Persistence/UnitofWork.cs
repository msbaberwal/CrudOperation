using ContactInformation.Core;
using ContactInformation.Core.Models;
using ContactInformation.Core.Repositories;
using ContactInformation.Persistence.Repositories;

namespace ContactInformation.Persistence
{
    public class UnitofWork : IUnitofWork
    {
        private readonly ApplicationDbContext _context;

        public IContactRepository Contacts { get; private set; }

        public UnitofWork(ApplicationDbContext context)
        {
            _context = context;
            Contacts = new ContactRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}