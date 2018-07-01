using ContactInformation.Core.Models;
using System.Collections.Generic;

namespace ContactInformation.Core.Repositories
{
    public interface IContactRepository
    {
        Contact FindContactUsingId(int id);
        Contact GetSingleContact(int id, string userid);
        IEnumerable<Contact> ListofContacts(string userid);
        void Add(Contact contact);
        void Remove(Contact contact);
    }
}