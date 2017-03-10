using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Domain.Partijen;

namespace Domain.Vragen
{
    public class TestVraag : Vraagtstelling
    {
        public TestAntwoord Antwoord1 { get; set; }
        public TestAntwoord Antwoord2 { get; set; }
        Thema Thema { get; set; }
        Niveau Niveau { get; set; }
        int Id { get; set; }

        public TestVraag(string text, int id, TestAntwoord antwoord1, TestAntwoord antwoord2, Thema thema, Niveau niveau) : base(text, id)
        {
            Antwoord1 = antwoord1;
            Antwoord2 = antwoord2;
            Thema = thema;
            Niveau = niveau;
        }
    }
}
