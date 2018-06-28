using ContactInformation.Models;
using ContactInformation.ViewModel;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(ContactFormViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", contactViewModel);
            }

            var contact = new Contact
            {
                UserId = User.Identity.GetUserId(),
                FirstName = contactViewModel.FirstName,
                LastName = contactViewModel.LastName,
                EmailId = contactViewModel.EmailId,
                Status = contactViewModel.Status,
                PhoneNumber = contactViewModel.PhoneNumber
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}