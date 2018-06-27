using System.Web.Mvc;

namespace ContactInformation.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ActionResult Create()
        {
            return View();
        }
    }
}