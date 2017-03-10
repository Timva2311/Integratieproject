using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Beslissingen;
using Domain.Vragen;

namespace UI.Models
{
    public class TestViewModel
    {
        public TestVraag CurrentVraag { get; set; }
        public Resultaat CurrentResultaat { get; set; }

        public TestViewModel(TestVraag currentVraag, Resultaat currentResultaat)
        {
            CurrentVraag = currentVraag;
            CurrentResultaat = currentResultaat;
        }

        public TestViewModel() { }
    }
}