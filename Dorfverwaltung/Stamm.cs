using System.Collections.Generic;


namespace Dorfverwaltung
{
    public class Stamm
    {
        public string Name { get; set; }
        public int GruendungNdK { get; set; }
        public string Stammeshaupt { get; set; }
        public int StammeshauptSeit { get; set; }
        public List<Zwerg> Mitglieder { get; set; }

        public Stamm(string name, int gruendung, string stammeshaupt, int stammmeshautpseit, List<Zwerg> zwerge)
        {
            Name = name;
            GruendungNdK = gruendung;
            Stammeshaupt = stammeshaupt;
            StammeshauptSeit = stammmeshautpseit;
            Mitglieder = zwerge;
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
        public void AddZwerg(Stamm stamm, Zwerg zwerg)
        {
            stamm.Mitglieder.Add(zwerg);
            SummeDesMachtfaktors(stamm);
        }
        public void RemoveZwerg(Stamm stamm, Zwerg zwerg)
        {
            stamm.Mitglieder.Remove(zwerg);
            SummeDesMachtfaktors(stamm);
        }
    }
}
