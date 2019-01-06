using System;
using System.Collections.Generic;
/*
 *################################################################
 * 
 *  Diese Datei enthält die Klasse Stamm.
 *  
 *################################################################
 */

namespace Dorfverwaltung
{
    public class Stamm : IDuke
    {
        //Dem Stamm einen Namen geben
        public string Name { get; set; }
        //Eine Spezies dem Stamm zuordnen (Elben und Zwerge bleiben unter sich.)
        public string Species { get; set; }
        //Dem Stamm ein Gründungsjahr eintragen
        public int GruendungNdK { get; set; }
        //Wer leitet den Stamm?
        public string Stammeshaupt { get; set; }
        //Wie lange wird der Stamm durch das Stammeshaupt angeführt?
        public int StammeshauptSeit { get; set; }
        //Externe Abfrage (redundant, da LeaderSince das selbe ist wie StammeshauptSeit, aber da die Interfaces nutzbar sein sollten, brauche ich das hier. [Ginge aber auch anders...])
        public int LeaderSince => StammeshauptSeit;
        //Siehe LeaderSince - das selbe wie Summe des Machtfaktors, berechnetes Feld.
        public int Tax => SummeDesMachtfaktors(this);
        //Welche Mitglieder hat der Stamm?
        public List<Lebewesen> Mitglieder { get; set; }

        //Der Konstruktor für unseren Stamm.
        public Stamm(string name, string species, int gruendung, string stammeshaupt, int stammmeshautpseit, List<Lebewesen> mitglieder)
        {
            //Hier erzeugen wir einen neuen Stamm und geben ihm Argumente, mithilfe derer der Stamm bestimmt wird.
            Name = name;
            Species = species;
            GruendungNdK = gruendung;
            Stammeshaupt = stammeshaupt;
            StammeshauptSeit = stammmeshautpseit;
            Mitglieder = mitglieder;
        }

        //Methode zur Berechnung des StammesMachtfaktors.
        public static int SummeDesMachtfaktors(Stamm stamm)
        {
            //Wir setzen einen Integer auf Null
            int machtFaktor = 0;
            //Und für jeden Zwerg (oder Elb - Man könnte hier statt zwerg aber auch Joghurt schreiben - ich kommentiere jetzt aber nur noch.) addieren wir dessen Machtfaktor.
            foreach (var zwerg in stamm.Mitglieder)
            {
                machtFaktor += zwerg.Machtfaktor;
            }
            //und geben am Schluss die Summe der Machtfaktoren aller Stammesmitglieder aus.
            return machtFaktor;
        }
        //Methode zum Hinzufügen von Stammesmitgliedern
        public void AddBewohner(Stamm stamm, Lebewesen Bewohner)
        {
            //Fügt der Mitgliederliste einen Eintrag hinzu
            stamm.Mitglieder.Add(Bewohner);
            //Updated den Machtfaktor des Stamms
            SummeDesMachtfaktors(stamm);
        }

        //Methode zum Entfernen eines Stammesmitglieds
        public void RemoveBewohner(Stamm stamm, Lebewesen Bewohner)
        {
            //Entfernen eines Eintrags aus der Mitgliederliste
            stamm.Mitglieder.Remove(Bewohner);
            //Updated den Machtfaktor des Stamms
            SummeDesMachtfaktors(stamm);
        }
    }
}
