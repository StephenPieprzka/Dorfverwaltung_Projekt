using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    public class Zwerg
    {
        string Name { get; set; }
        int Alter { get; set; }
        string Stamm { get; set; }
        public int Machtfaktor { get; set; }

        public List<Gegenstand> Inventar = new List<Gegenstand>();

        public Zwerg(string name, int alter, string stamm, int machtfaktor)
        {
            Name = name;
            Alter = alter;
            Stamm = stamm;
            Machtfaktor = machtfaktor;
        }
        public void AddItem(Zwerg zwerg, Gegenstand item)
        {
            zwerg.Inventar.Add(item);
            UpdateMachtfaktor(zwerg);
        }
        public void RemoveItem(Zwerg zwerg, Gegenstand item)
        {
            zwerg.Inventar.Remove(item);
            UpdateMachtfaktor(zwerg);
        }

        public static void UpdateMachtfaktor(Zwerg zwerg)
        {
            int newMachtfaktor = 0;
            foreach (var gegenstand in zwerg.Inventar)
            {
                newMachtfaktor += gegenstand.MagieWert;
            }
            zwerg.Machtfaktor = newMachtfaktor;
        }
    }
}
