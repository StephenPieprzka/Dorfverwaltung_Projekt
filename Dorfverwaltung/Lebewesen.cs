using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    public abstract class Lebewesen : IInhabitant
    {
        public string Name { get; set; }
        public string Spezies { get; set; }
        public int Alter { get; set; }
        public string Stamm { get; set; }
        public int Machtfaktor { get; set; }
        public int Tax
        {
            get => Machtfaktor;
        }
    }
}
