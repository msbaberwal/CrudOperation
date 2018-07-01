using ContactInformation.Core;
using ContactInformation.Core.Models;
using ContactInformation.Core.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public ContactsController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
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
            var contact = _unitofWork.Contacts.GetSingleContact(id, User.Identity.GetUserId());
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

            _unitofWork.Contacts.Add(contact);
            _unitofWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Search(ContactViewModel viewModel)
        {
            if (viewModel == null) throw new ArgumentNullException(nameof(viewModel));
            return RedirectToAction("Index", "Home", new { query = viewModel.SearchTerm });
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

            var contact = _unitofWork.Contacts.GetSingleContact(contactViewModel.Id, User.Identity.GetUserId());

            contact.FirstName = contactViewModel.FirstName;
            contact.LastName = contactViewModel.LastName;
            contact.EmailId = contactViewModel.EmailId;
            contact.PhoneNumber = contactViewModel.PhoneNumber;
            contact.Status = contactViewModel.Status;

            _unitofWork.Complete();

            return RedirectToAction("Index", "Home");
        }
    }
}