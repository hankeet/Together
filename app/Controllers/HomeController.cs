using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize(Roles ="admins")]
        public ActionResult Index()
        {
            return View();
        }
    }
}