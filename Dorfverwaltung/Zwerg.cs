using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *################################################################
 * 
 *  Diese Datei enthält die Klasse Zwerg.
 *  
 *################################################################
 */

namespace Dorfverwaltung
{
    //Die Klasse Zwerg erbt von der Klasse Lebewesen und impelementiert das Interface IInhabitant.
    public class Zwerg : Lebewesen,IInhabitant
    {
        //Für das Interface notwendiger Integer Tax - zur Abfrage von außen.
        public int Tax
        {
            //dieser basiert auf dem Machtfaktor des Zwergs multipliziert mit dem Steuerbasissatz der im Programm festlegbar ist.
            get => Machtfaktor * Program.SteuerBasisSatz;
        }

        //Zwerge haben viele Gegenstände im Inventar - daher eine Liste.
        public List<Gegenstand> Inventar = new List<Gegenstand>();

        //Unser Standardkonstruktor für Zwerge.
        public Zwerg()
        {
            //Hier erzeugen wir einen neuen Zwerg und geben ihm Standardargumente.
            Name = "Max MusterZwerg";
            Spezies = "Zwerg";
            Alter = 0;
            Stamm = "";
            Machtfaktor = 0;
        }
        public Zwerg(string name, int alter, string stamm, int machtfaktor)
        {
            //Hier erzeugen wir einen neuen Zwerg und geben ihm Argumente, mithilfe derer der Zwerg bestimmt wird.
            Name = name;
            Spezies = "Zwerg";
            Alter = alter;
            Stamm = stamm;
            Machtfaktor = machtfaktor;
        }

        //Methode, um Zwergen Gegenstände zu geben.
        public void AddItem(Zwerg zwerg, Gegenstand item)
        {
            //Fügt der Gegenstandsliste des Zwergs einen Gegenstand hinzu.
            zwerg.Inventar.Add(item);
            //Updated den Machtfaktor des Zwergs.
            UpdateMachtfaktor(zwerg);
        }

        //Methode, um Zwergen Gegenstände zu nehmen.
        public void RemoveItem(Zwerg zwerg, Gegenstand item)
        {
            //Entfernt einen Gegenstand aus der Gegenstandsliste des Zwergs.
            zwerg.Inventar.Remove(item);
            //Updated den Machtfaktor des Zwergs.
            UpdateMachtfaktor(zwerg);
        }

        //Methode, um den Machtfaktor des Zwergs zu aktualisieren.
        public static void UpdateMachtfaktor(Zwerg zwerg)
        {
            //Wir setzen einen Integer auf Null
            int newMachtfaktor = 0;
            //Für jeden Gegenstand addieren wir nun den MagieWert des Gegenstands zum Machtfaktor des Zwergs hinzu.
            foreach (var gegenstand in zwerg.Inventar)
            {
                newMachtfaktor += gegenstand.MagieWert;
            }
            //Am Schluss geben wir den neuen Machtfaktor aus.
            zwerg.Machtfaktor = newMachtfaktor;
        }
    }
}
