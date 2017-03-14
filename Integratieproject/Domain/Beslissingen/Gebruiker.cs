using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Beslissingen;

namespace Domain
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public HashSet<Eigenschap> Eigenschappen { get; set; }

        public Gebruiker(int id)
        {
            this.Id = id;
            Eigenschappen = new HashSet<Eigenschap>();
        }
    }
}
