using ContactInformation.Models;
using ContactInformation.ViewModel;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Index(string query = null)
        {
            var userid = User.Identity.GetUserId();

            var listofContacts = _context.Contacts.ToList().Where(c => c.UserId == userid);

            if (!String.IsNullOrWhiteSpace(query))
            {
                listofContacts = listofContacts.Where(c =>
                    c.FirstName.Contains(query) ||
                    c.LastName.Contains(query) ||
                    c.EmailId.Contains(query) ||
                    c.PhoneNumber.Contains(query)
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
    }
}