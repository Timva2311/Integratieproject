using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public partial class EndController : Controller
    {

        // GET: End
        public virtual ActionResult Index()
        {
            TestViewModel mod = (TestViewModel)TempData["mod"];
            return View(mod);
        }
    }
}