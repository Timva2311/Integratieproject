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
    public class TestController : Controller
    {
        private VraagManager _mng;
        private static int niveauCounter=1;
        TestViewModel mymodel;

        public TestController()
        {
            _mng = new VraagManager();
            mymodel = new TestViewModel();
            mymodel.CurrentGebruiker = _mng.GetUser();
        }
        // GET: Test
        public ActionResult Test()
        {
            if (_mng.GetNextQuestion(niveauCounter + 1) == null)
            {

                mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter);
                niveauCounter = 1;
                mymodel.CurrentGebruiker = _mng.ResetUser();
                return RedirectToAction("Index", "Home");
            }
            mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter);
            return View(mymodel);
        }
        public ActionResult NextQuestion(bool keuze)
        {
            Random r = new Random();
            double d = r.NextDouble() * (1 - 0) + 0;
            if (_mng.GetNextQuestion(niveauCounter + 1) == null)
            {
                
                mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter);
                TestViewModel m = mymodel;
                TempData["mod"] = m;
                return RedirectToAction("Index", "End", "m");
            }
            mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter + 1);
            if (keuze==true)
            {
                if (d>=0 && d<=_mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.Kans)
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
                else if (d > _mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.Kans && d <= _mng.GetNextQuestion(niveauCounter).Antwoord1.EindResultaat.Kans + _mng.GetNextQuestion(niveauCounter).Antwoord1.FaalResultaat.Kans)
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord1.FaalResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord1.FaalResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord1.FaalResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord1.FaalResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
                else
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord1.SuccesResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord1.SuccesResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord1.SuccesResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord1.SuccesResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
            }
            if (keuze == false)
            {
                if (d >= 0 && d <= _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.Kans)
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
                else if (d > _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.Kans && d <= _mng.GetNextQuestion(niveauCounter).Antwoord2.EindResultaat.Kans + _mng.GetNextQuestion(niveauCounter).Antwoord2.FaalResultaat.Kans)
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord2.FaalResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord2.FaalResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord2.FaalResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord2.FaalResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
                else
                {
                    mymodel.CurrentResultaat = _mng.GetNextQuestion(niveauCounter).Antwoord2.SuccesResultaat;
                    if (_mng.GetNextQuestion(niveauCounter).Antwoord2.SuccesResultaat.VolgendeVraag != null)
                    {
                        mymodel.CurrentVraag = _mng.GetNextQuestion(niveauCounter).Antwoord2.SuccesResultaat.VolgendeVraag;
                    }
                    foreach (var item in _mng.GetNextQuestion(niveauCounter).Antwoord2.SuccesResultaat.EigenschappenToUpdate)
                    {
                        mymodel.CurrentGebruiker = _mng.AddNewUserProp(item);
                    }
                }
            }
            niveauCounter++;
            return View("Test", mymodel);
        }
    }
}