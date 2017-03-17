using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Domain.Vragen;
using UI.Models;
using Domain;
using Domain.Beslissingen;

namespace UI.Controllers
{
    public partial class TestController : Controller
    {
        private VraagManager _mng;
        private static int niveauCounter = 1;
        TestViewModel mymodel;
        
        public TestController()
        {
            _mng = new VraagManager();
            mymodel = new TestViewModel();
            mymodel.CurrentGebruiker = _mng.GetUser();

        }
        // GET: Test
        public virtual ActionResult Test()
        {
            mymodel.CurrentGebruiker = _mng.NewUser();
            mymodel.CurrentVraag = _mng.GetQuestion(niveauCounter);
            return View(mymodel);
        }
        public virtual ActionResult NextQuestion(int keuze)
        {
            Resultaat resultaat;
            Gebruiker gebruiker = mymodel.CurrentGebruiker;
            TestVraag currentVraag;
            TestVraag nextVraag;
            if (!_mng.GetNextQuestion(niveauCounter, keuze, out resultaat, out nextVraag,out currentVraag,
                out gebruiker))
            {
                niveauCounter = 1;
                return RedirectToAction(MVC.Home.Index());
            }
            niveauCounter++;
            mymodel.CurrentVraag = nextVraag;
            Session["Gebruiker"] = mymodel.CurrentGebruiker;
            return View(Views.Test, mymodel);
        }
    }
}