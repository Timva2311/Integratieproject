using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Beslissingen;
using Domain.Vragen;
using Domain;

namespace UI.Models
{
    public class TestViewModel
    {
        public TestVraag CurrentVraag { get; set; }
        public Resultaat CurrentResultaat { get; set; }
        public Gebruiker CurrentGebruiker { get; set; }

        public TestViewModel(TestVraag currentVraag, Resultaat currentResultaat, Gebruiker gebruiker)
        {
            CurrentVraag = currentVraag;
            CurrentResultaat = currentResultaat;
            CurrentGebruiker = gebruiker;
        }

        public TestViewModel() {
            CurrentResultaat = new Resultaat();
        }
    }
}