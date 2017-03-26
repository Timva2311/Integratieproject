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
            Session["BeantwoordeVragen"] = null;
            mymodel.CurrentGebruiker = _mng.NewUser();
            mymodel.CurrentVraag = _mng.GetQuestion(niveauCounter);
            return View(mymodel);
        }
        public virtual ActionResult NextQuestion(int keuze)
        {
            TestAntwoord selectedAntwoord;
            Resultaat resultaat;
            Gebruiker gebruiker = mymodel.CurrentGebruiker;
            TestVraag currentVraag;
            TestVraag nextVraag;

            mymodel.BeantwoordeVragen = (Dictionary<String, String>)Session["BeantwoordeVragen"];
            if (mymodel.BeantwoordeVragen == null)
            {
                mymodel.BeantwoordeVragen = new Dictionary<string, string>();
            }

            if (!_mng.GetNextQuestion(niveauCounter, keuze, out selectedAntwoord, out resultaat, out nextVraag,out currentVraag,
                out gebruiker))
            {
                mymodel.CurrentVraag = currentVraag;
                TempData["mod"] = mymodel;
                niveauCounter = 1;
                return RedirectToAction("Index", "End", mymodel);
            }
            niveauCounter++;
            mymodel.CurrentVraag = nextVraag;
            mymodel.CurrentResultaat = resultaat;
            Session["Gebruiker"] = mymodel.CurrentGebruiker;
            mymodel.BeantwoordeVragen.Add(currentVraag.Text, selectedAntwoord.Text);
            Session["BeantwoordeVragen"] = mymodel.BeantwoordeVragen;
            _mng.AddBeantwoordeVraag(currentVraag.Text, selectedAntwoord.Text);
            return View(Views.Test, mymodel);
        }
    }
}