using System.Collections.Generic;
using System.Linq;
using ContactInformation.Core.Models;
using ContactInformation.Core.Repositories;

namespace ContactInformation.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact GetSingleContact(int id, string userid)
        {
            return _context.Contacts.Single(g => g.Id == id &&
                                                 g.UserId == userid);
        }

        public IEnumerable<Contact> ListofContacts(string userid)
        {
            return _context.Contacts.ToList().Where(c => c.UserId == userid);
        }

        public void Add(Contact contact)
        {
            _context.Contacts.Add(contact);

        }
    }
}