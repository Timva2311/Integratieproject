using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Vragen;

namespace UI.Models
{
    public class AdminViewModel
    {
        public List<TestVraag> Vragen;

        public AdminViewModel(List<TestVraag> vragen)
        {
            Vragen = vragen;
        }
    }
}