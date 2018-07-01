using System.Collections.Generic;
using ContactInformation.Core.Models;

namespace ContactInformation.Core.ViewModel
{
    public class ContactViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<Contact> ListofContacts { get; set; }
    }
}