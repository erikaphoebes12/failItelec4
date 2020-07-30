using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBread.Controllers
{
    public class SoftwareController : Controller
    {
        // GET: Software
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }
        
        public ActionResult Students()
        {
            return View();
        }
    }
}