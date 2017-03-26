using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Vragen;
using Domain;
using Domain.Beslissingen;

namespace BL
{
    public class VraagManager
    {
        private TestRepository _rep { get; set; }

        public VraagManager()
        {
            _rep = new TestRepository();
        }

        public bool GetNextQuestion(int niveau, int keuze, out TestAntwoord selectedAntwoord, out Resultaat resultaat, out TestVraag nextVraag, out TestVraag currentVraag, out Gebruiker gebruiker)
        {
            resultaat = null;
            gebruiker = null;
            selectedAntwoord = null;
            currentVraag = GetVraagEnAntwoord(niveau, keuze, out selectedAntwoord);
            nextVraag = _rep.GetVraagByIndex(niveau + 1);

            if (nextVraag == null)
            {
                return false;
            }

            Random r = new Random();
            double d = r.NextDouble() * (1 - 0) + 0;
            if (d >= 0 && d <= selectedAntwoord.EindResultaat.Kans)
            {
                resultaat = selectedAntwoord.EindResultaat;
                if (selectedAntwoord.EindResultaat.VolgendeVraag != null)
                {
                    nextVraag = selectedAntwoord.EindResultaat.VolgendeVraag;
                }
                foreach (var item in selectedAntwoord.EindResultaat.EigenschappenToUpdate)
                {
                    gebruiker = AddNewUserProp(item);
                }
            }
            else if (d > selectedAntwoord.EindResultaat.Kans && d <= selectedAntwoord.EindResultaat.Kans + currentVraag.Antwoord1.FaalResultaat.Kans)
            {
                resultaat = selectedAntwoord.FaalResultaat;
                if (selectedAntwoord.FaalResultaat.VolgendeVraag != null)
                {
                   nextVraag = selectedAntwoord.FaalResultaat.VolgendeVraag;
                }
                foreach (var item in selectedAntwoord.FaalResultaat.EigenschappenToUpdate)
                {
                    gebruiker= AddNewUserProp(item);
                }
            }
            else
            {
                resultaat = selectedAntwoord.SuccesResultaat;
                if (selectedAntwoord.SuccesResultaat.VolgendeVraag != null)
                {
                    nextVraag = selectedAntwoord.SuccesResultaat.VolgendeVraag;
                }
                foreach (var item in selectedAntwoord.SuccesResultaat.EigenschappenToUpdate)
                {
                   gebruiker = AddNewUserProp(item);
                }
            }

            return true;
        }

        public TestVraag GetVraagEnAntwoord(int niveau, int i, out TestAntwoord antwoord)
        {
            var vraag = _rep.GetVraagByIndex(niveau);
            if(i == 1) antwoord = vraag.Antwoord1;
            else if (i == 2) antwoord = vraag.Antwoord2;
            else antwoord = null;
            return vraag;
        }

        public Gebruiker GetUser()
        { 
        
            return _rep.GetUser();
        }

        public Gebruiker AddNewUserProp(Eigenschap item)
        {
            return _rep.AddNewUserProp(item);
        }

        public Gebruiker NewUser()
        {
            return _rep.NewUser();
        }

        public TestVraag GetQuestion(int niveau)
        {
            return _rep.GetVraagByIndex(niveau);
        }

        public void AddBeantwoordeVraag(string currentVraagText, string selectedAntwoordText)
        {
            _rep.AddBeantwoordeVraag(currentVraagText, selectedAntwoordText);
        }
    }
}
