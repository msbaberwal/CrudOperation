using Microsoft.AspNet.Identity;
using System.Web.Http;
using ContactInformation.Core.Models;
using ContactInformation.Persistence;

namespace ContactInformation.Controllers.Api
{
    [Authorize]
    public class ContactsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            var userid = User.Identity.GetUserId();
            if (id != 0)
            {
                var contact = _context.Contacts.Find(id);
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return Ok();
            }

            return NotFound();
        }
    }
}