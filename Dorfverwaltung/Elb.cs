using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    public class Elb : Lebewesen, IInhabitant
    {
        public float Haarlaenge = 0;
        public int Tax
        {
            get => (int)((Alter / Program.SteuerBasisSatz) + Haarlaenge);
        }
        public List<Gegenstand> Inventar = new List<Gegenstand>();
        public Elb()
        {
            Name = "Max MusterElb";
            Spezies = "Elb";
            Alter = 0;
            Stamm = "";
            Machtfaktor = 0;
        }
        public Elb(string name, int alter, string stamm, int machtfaktor,bool idioticMeasurement, float haarlaenge)
        {
            Name = name;
            Spezies = "Elb";
            Alter = alter;
            Stamm = stamm;
            Machtfaktor = machtfaktor;
            if (idioticMeasurement)
            {
                Haarlaenge = haarlaenge * 2.54f;
            }
            else
                Haarlaenge = haarlaenge;
        }
        public void HaareWachsenLassen(Elb elb, float länge)
        {
            elb.Haarlaenge += länge;
            UpdateMachtfaktor(elb);
        }
        public void HaareSchneiden(Elb elb, float länge)
        {
            elb.Haarlaenge = länge;
            UpdateMachtfaktor(elb);
        }

        public static void UpdateMachtfaktor(Elb elb)
        {
            int newMachtfaktor = 0;
            newMachtfaktor = (int)((elb.Alter / Program.SteuerBasisSatz) + elb.Haarlaenge);
            elb.Machtfaktor = newMachtfaktor;
        }
    }
}
