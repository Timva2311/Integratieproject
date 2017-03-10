﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Beslissingen;

namespace Domain.Vragen
{
    public class TestAntwoord
    {
        public String Text { get; set; }
        public List<String> Voordelen { get; set; }
        public List<String> Nadelen { get; set; }
        public List<Resultaat> Resultaten { get; set; }

        public TestAntwoord(string text, List<string> voordelen, List<string> nadelen)
        {
            Nadelen = nadelen;
            Voordelen = voordelen;
            Text = text;
        }
    }
}
