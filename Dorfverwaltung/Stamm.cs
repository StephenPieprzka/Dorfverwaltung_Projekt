using System.Collections.Generic;


namespace Dorfverwaltung
{
    public class Stamm
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public int GruendungNdK { get; set; }
        public string Stammeshaupt { get; set; }
        public int StammeshauptSeit { get; set; }
        public List<Lebewesen> Mitglieder { get; set; }

        public Stamm(string name, string species, int gruendung, string stammeshaupt, int stammmeshautpseit, List<Lebewesen> mitglieder)
        {
            Name = name;
            Species = species;
            GruendungNdK = gruendung;
            Stammeshaupt = stammeshaupt;
            StammeshauptSeit = stammmeshautpseit;
            Mitglieder = mitglieder;
        }
        public static int SummeDesMachtfaktors(Stamm stamm)
        {
            int machtFaktor = 0;
            foreach (var zwerg in stamm.Mitglieder)
            {
                machtFaktor += zwerg.Machtfaktor;
            }
            return machtFaktor;
        }
        public void AddBewohner(Stamm stamm, Lebewesen Bewohner)
        {
            stamm.Mitglieder.Add(Bewohner);
            SummeDesMachtfaktors(stamm);
        }
        public void RemoveBewohner(Stamm stamm, Lebewesen Bewohner)
        {
            stamm.Mitglieder.Remove(Bewohner);
            SummeDesMachtfaktors(stamm);
        }
    }
}
