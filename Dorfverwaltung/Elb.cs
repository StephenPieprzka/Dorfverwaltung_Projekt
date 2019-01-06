using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *################################################################
 * 
 *  Diese Datei enthält die Klasse Elb.
 *  
 *################################################################
 */

namespace Dorfverwaltung
{
    //Die Klasse Elb erbt von der Klasse Lebewesen und impelementiert das Interface IInhabitant.
    public class Elb : Lebewesen, IInhabitant
    {
        //Elben haben langes Haar - wie lang dieses ist, setzen wir mit diesem Integer.
        public float Haarlaenge = 0;
        //Für das Interface notwendiger Integer Tax - zur Abfrage von außen.
        public int Tax
        {
            //Den Wert bekommen wir basierend auf der Aufgabenstellung von Alter, Steuerbasissatz und Haarlänge.
            get => (int)((Alter / Program.SteuerBasisSatz) + Haarlaenge);
        }
        //Elben besitzen zwar nicht die "Verandlagung", Gegenstände zu besitzen, aber vielleicht leiht sich einer ja eine Schaufel?
        public List<Gegenstand> Inventar = new List<Gegenstand>();
        //Standardkonstruktor, ohne Parameter, erstellt mit Standardwerten einen neuen Elben.
        public Elb()
        {
            Name = "Max MusterElb";
            Spezies = "Elb";
            Alter = 0;
            Stamm = "";
            Machtfaktor = 0;
        }
        //Konstruktor, der basierend auf Parametern einen neuen Elben erstellt und diesem die übergebenen Werte als Eigenschaften gibt.
        public Elb(string name, int alter, string stamm, int machtfaktor,bool idioticMeasurement, float haarlaenge)
        {
            Name = name;
            Spezies = "Elb";
            Alter = alter;
            Stamm = stamm;
            Machtfaktor = machtfaktor;
            //Es gab mal einen Elben, der maß sein Haar nicht metrisch sondern nach imperialem Maße...
            if (idioticMeasurement)
            {
                //... daher muss hier eine Umrechnung stattfinden
                Haarlaenge = haarlaenge * 2.54f;
            }
            else
                Haarlaenge = haarlaenge;
        }
        //Methode, um das Haar eines Elben wachsen zu lassen.
        public void HaareWachsenLassen(Elb elb, float länge)
        {
            //Änderung der Länge
            elb.Haarlaenge += länge;
            //Aktualisierung des Machtfaktors
            UpdateMachtfaktor(elb);
        }
        //Methode, um das Haar eines Elben auf eine bestimmte Länge zu kürzen.
        public void HaareSchneiden(Elb elb, float länge)
        {
            //Änderung der Länge auf festen Wert
            elb.Haarlaenge = länge;
            //Aktualisierung des Machtfaktors
            UpdateMachtfaktor(elb);
        }

        //Methode, um den Machtfaktor eines Elben zu aktualisieren.
        public static void UpdateMachtfaktor(Elb elb)
        {
            //Integer auf 0
            int newMachtfaktor = 0;
            //Berechnen des neuen Machtfaktors basierend auf Alter, Basissteuersatz aus dem Programm und der Haarlänge des Elben.
            newMachtfaktor = (int)((elb.Alter / Program.SteuerBasisSatz) + elb.Haarlaenge);
            //Aktualisieren des Machtfaktors.
            elb.Machtfaktor = newMachtfaktor;
        }
    }
}
