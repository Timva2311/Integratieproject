using Domain.Vragen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Beslissingen
{
    public class Resultaat
    {
        public int Id { get; set; }
        public String Text { get; set; }
        public double Kans { get; set; }
        public List<Eigenschap> EigenschappenToUpdate { get; set; }
        public TestVraag VolgendeVraag { get; set; }

        public Resultaat()
        {
            EigenschappenToUpdate = new List<Eigenschap>();
        }
    }
}
