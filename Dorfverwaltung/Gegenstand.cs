using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    public class Gegenstand
    {
        public string Name { get; set; }
        public int MagieWert { get; set; }

        public Gegenstand(string name, int magieWert)
        {
            Name = name;
            MagieWert = magieWert;
        }
    }
}
