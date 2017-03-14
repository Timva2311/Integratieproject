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

        public Eigenschap(int id, String naam, Status status)
        {
            this.Id = id;
            this.Naam = naam;
            this.Status = status;
        }

        public override bool Equals(object obj)
        {
            var item = obj as Eigenschap;

            if (item == null)
            {
                return false;
            }

            if (this.Id == item.Id && this.Naam.Equals(item.Naam) && this.Status == item.Status)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
