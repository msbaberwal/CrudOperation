using ContactInformation.Models;
using ContactInformation.ViewModel;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System.Linq;
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
            var viewModel = new ContactFormViewModel()
            {
                Heading = "Add a Contact"
            };
            return View("ContactForm", viewModel);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userid = User.Identity.GetUserId();
            var contact = _context.Contacts.Single(g => g.Id == id &&
                                                        g.UserId == userid);
            var viewModel = new ContactFormViewModel()
            {
                Heading = "Edit a Contact",
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                EmailId = contact.EmailId,
                Status = contact.Status
            };
            return View("ContactForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactFormViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactForm", contactViewModel);
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

            _context.Contacts.AddOrUpdate(contact);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(ContactViewModel viewModel)
        {
            return RedirectToAction("Index", "Home", new {query = viewModel.SearchTerm});
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ContactFormViewModel contactViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("ContactForm", contactViewModel);
            }

            var userid = User.Identity.GetUserId();
            var contact = _context.Contacts.Single(c => c.Id == contactViewModel.Id
                                                        && c.UserId == userid);

            contact.FirstName = contactViewModel.FirstName;
            contact.LastName = contactViewModel.LastName;
            contact.EmailId = contactViewModel.EmailId;
            contact.PhoneNumber = contactViewModel.PhoneNumber;
            contact.Status = contactViewModel.Status;

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}