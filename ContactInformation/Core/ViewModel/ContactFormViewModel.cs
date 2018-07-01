using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using ContactInformation.Controllers;

namespace ContactInformation.Core.ViewModel
{
    public class ContactFormViewModel
    {
        public int Id { get; set; }

        [Required] public string FirstName { get; set; }

        [Required] public string LastName { get; set; }

        [Required] [EmailAddress] public string EmailId { get; set; }

        [Required] [Phone] public string PhoneNumber { get; set; }

        [Required] public bool Status { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<ContactsController, ActionResult>> update =
                    (c => c.Update(this));
                Expression<Func<ContactsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }

        public string Heading { get; internal set; }
    }
}