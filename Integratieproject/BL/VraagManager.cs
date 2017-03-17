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

        public TestVraag GetNextQuestion(int niveau)
        {
            return _rep.GetVraagByIndex(niveau);
        }

        public Gebruiker GetUser()
        {
            return _rep.GetUser();
        }

        public Gebruiker AddNewUserProp(Eigenschap item)
        {
            return _rep.AddNewUserProp(item);
        }

        public Gebruiker ResetUser()
        {
            return _rep.ResetUser();
        }
    }
}
