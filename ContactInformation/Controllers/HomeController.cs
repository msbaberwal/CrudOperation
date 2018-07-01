using ContactInformation.Persistence;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;
using ContactInformation.Core;
using ContactInformation.Core.ViewModel;

namespace ContactInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        public HomeController(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        [Authorize]
        public ActionResult Index(string query = null)
        {
            var listofContacts = _unitofWork.Contacts.ListofContacts(User.Identity.GetUserId());

            if (!String.IsNullOrWhiteSpace(query))
            {
                query = query.ToUpper();

                listofContacts = listofContacts.Where(c =>
                    c.FirstName.ToUpper().Contains(query) ||
                    c.LastName.ToUpper().Contains(query) ||
                    c.EmailId.ToUpper().Contains(query) ||
                    c.PhoneNumber.ToUpper().Contains(query)
                );
            }

            var viewModel = new ContactViewModel
            {
                ListofContacts = listofContacts,
                SearchTerm = query
            };

            return View(viewModel);
        }



        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your About page.";

            return View();
        }
    }
}