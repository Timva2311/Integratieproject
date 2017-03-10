﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Vragen
{
    public class Vraagtstelling
    {
        public String Text { get; set; }
        public int Id { get; set; }

        public Vraagtstelling(string text, int id)
        {
            Text = text;
            Id = id;
        }
    }
}
