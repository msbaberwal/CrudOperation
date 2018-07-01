using ContactInformation.Models;
using System.Collections.Generic;

namespace ContactInformation.ViewModel
{
    public class ContactViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<Contact> ListofContacts { get; set; }
    }
}