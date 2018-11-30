using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    public class Zwerg : Lebewesen
    {
        public List<Gegenstand> Inventar = new List<Gegenstand>();
        public Zwerg()
        {
            Name = "Max MusterZwerg";
            Spezies = "Zwerg";
            Alter = 0;
            Stamm = "";
            Machtfaktor = 0;
        }
        public Zwerg(string name, int alter, string stamm, int machtfaktor)
        {
            Name = name;
            Spezies = "Zwerg";
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
