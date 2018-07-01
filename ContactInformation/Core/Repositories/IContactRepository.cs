using System.Collections.Generic;
using ContactInformation.Core.Models;

namespace ContactInformation.Core.Repositories
{
    public interface IContactRepository
    {
        Contact GetSingleContact(int id, string userid);
        IEnumerable<Contact> ListofContacts(string userid);
        void Add(Contact contact);
    }
}