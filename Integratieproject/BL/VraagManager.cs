using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Domain.Vragen;

namespace BL
{
    public class VraagManager
    {
        private TestRepository _rep { get; set; }

        public VraagManager()
        {
            _rep = new TestRepository();
        }

        public TestVraag GetNextQuestion(int index)
        {
            return _rep.GetVraagByIndex(index);
        }
    }
}
