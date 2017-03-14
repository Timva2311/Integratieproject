using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Domain.Partijen;
using Domain.Beslissingen;

namespace Domain.Vragen
{
    public class TestVraag : Vraagtstelling
    {
        public TestAntwoord Antwoord1 { get; set; }
        public TestAntwoord Antwoord2 { get; set; }
        public Thema Thema { get; set; }
        public Niveau Niveau { get; set; }
        int Id { get; set; }
        public List<Eigenschap> Eigenschappen { get; set; }
        public List<Resultaat> Resultaten { get; set; }

        public TestVraag(string text, int id, TestAntwoord antwoord1, TestAntwoord antwoord2, Thema thema, Niveau niveau) : base(text, id)
        {
            Antwoord1 = antwoord1;
            Antwoord2 = antwoord2;
            Thema = thema;
            Niveau = niveau;
            Eigenschappen = new List<Eigenschap>();
            Resultaten = new List<Resultaat>();
        }
    }
}
