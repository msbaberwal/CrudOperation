using ContactInformation.Models;
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
        public ActionResult Index()
        {
            var listofContacts = _context.Contacts.ToList();

            return View(listofContacts);
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}