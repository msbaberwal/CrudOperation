using ContactInformation.Core.Models;
using ContactInformation.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ContactInformation.Persistence.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Contact FindContactUsingId(int id)
        {
            return _context.Contacts.Find(id);
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
        public void Remove(Contact contact)
        {
            _context.Contacts.Remove(contact);

        }
    }
}