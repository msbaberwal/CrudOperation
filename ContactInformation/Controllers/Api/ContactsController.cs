using ContactInformation.Core;
using ContactInformation.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;

namespace ContactInformation.Controllers.Api
{
    [Authorize]
    public class ContactsController : ApiController
    {
        private readonly IUnitofWork _unitofWork;
        private readonly ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        public ContactsController(IUnitofWork unitofWork)
        {
            this._unitofWork = unitofWork;
        }

        [HttpDelete]
        public IHttpActionResult Cancel(int id)
        {
            if (id != 0)
            {
                var userid = User.Identity.GetUserId();

                try
                {
                    var contact = _unitofWork.Contacts.FindContactUsingId(id);
                    _unitofWork.Contacts.Remove(contact);
                    _unitofWork.Complete();
                }
                catch (Exception e)
                {
                    Console.WriteLine("" + e.Message);
                    return NotFound();
                }
                return Ok();
            }

            return NotFound();
        }
    }
}