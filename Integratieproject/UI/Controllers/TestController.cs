using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Domain.Vragen;

namespace UI.Controllers
{
    public class TestController : Controller
    {
        private VraagManager _mng;
        private int vraagCounter;
        private TestVraag currentVraag;
        public TestController()
        {
            _mng = new VraagManager();
            vraagCounter = 0;
        }
        // GET: Test
        public ActionResult Test()
        {
            currentVraag = _mng.GetNextQuestion(vraagCounter);
            return View(currentVraag);
        }
    }
}