using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Domain.Vragen;
using UI.Models;

namespace UI.Controllers
{
    public class TestController : Controller
    {
        private VraagManager _mng;
        private int vraagCounter;
        public TestController()
        {
            _mng = new VraagManager();
            vraagCounter = 0;
        }
        // GET: Test
        public ActionResult Test()
        {
            TestViewModel mymodel = new TestViewModel();
            mymodel.CurrentVraag = _mng.GetNextQuestion(vraagCounter);
            if(vraagCounter != 0){/*Resultaat meegeven*/}
            return View(mymodel);
        }
    }
}