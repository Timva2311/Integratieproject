using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Beslissingen
{
    public class Eigenschap
    {
        public int Id { get; set; }
        public String Naam { get; set; }
        public Status Status { get; set; }
    }
}
