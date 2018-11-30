using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dorfverwaltung
{
    class Program
    {
        static Stamm Altobarden = new Stamm("Altobarden", 1247, "Gimli", 25, new List<Zwerg>() { });
        static Stamm Elbkbnechte = new Stamm("Elbknechte", 1023, "", 0, new List<Zwerg>() { });
        static List<Stamm> AlleClans = new List<Stamm>();


        static Zwerg Gimli = new Zwerg("Gimli", 140, "Altobarden", 0);
        static Zwerg Zwingli = new Zwerg("Zwingli", 70, "Altobarden", 0);
        static Zwerg Gumli = new Zwerg("Gumli", 163, "Elbknechte", 0);

        static Gegenstand Axt01 = new Gegenstand("Axt", 12);
        static Gegenstand Schwert = new Gegenstand("Schwert", 15);
        static Gegenstand Axt02 = new Gegenstand("Axt", 17);
        static Gegenstand Zauberstab = new Gegenstand("Zauberstab", 45);
        static Gegenstand Streithammer = new Gegenstand("Streithammer", 15);


        static bool running = true;
        static void Main(string[] args)
        {
            Gimli.Inventar.Add(Axt01);
            Gimli.Inventar.Add(Schwert);
            Zwerg.UpdateMachtfaktor(Gimli);
            Gumli.Inventar.Add(Axt02);
            Zwerg.UpdateMachtfaktor(Gumli);
            Zwingli.Inventar.Add(Zauberstab);
            Zwingli.Inventar.Add(Streithammer);
            Zwerg.UpdateMachtfaktor(Zwingli);
            Altobarden.Mitglieder.Add(Gimli);
            Altobarden.Mitglieder.Add(Zwingli);
            Elbkbnechte.Mitglieder.Add(Gumli);
            //Hinzufügen der Stämme zu einer Liste
            AlleClans.Add(Altobarden);
            AlleClans.Add(Elbkbnechte);
            while (running)
            {
                //Auswahl dem Nutzer überlassen
                Console.WriteLine("#   Willkommen zur Stammesverwaltung.  #");
                Console.WriteLine("###  Bitte wählen Sie eine Aktion    ###");
                Console.WriteLine("###      1: Staemme anzeigen         ###");
                Console.WriteLine("###      2: Staemme editieren        ###");
                Console.WriteLine("###      3: Zwerge anzeigen          ###");
                Console.WriteLine("###      4: Zwerg editieren          ###");
                Console.WriteLine("###      5: Inventar editieren       ###");
                //Aufruf der passenden Methode basierend auf Nutzerinput
                switch (Int32.Parse(Console.ReadLine()))
                {
                    case 2: EditAClan(); break;
                    case 3: ShowDwarf(); break;
                    case 4: EditDwarf(); break;
                    case 5: EditInventory(); break;
                    default: ShowAllClans(); break;
                }
            }
        }
        //Alle Staemme anzeigen
        static void ShowAllClans()
        {
            Console.WriteLine("###      1: Staemme anzeigen         ###");
            Console.WriteLine("Stammname        Stammesgründung     Stammesfuehrer + seit");
            //Schleife für alle Staemme
            foreach (var stamm in AlleClans)
            {
                //Berechnung des Machtfaktors des Clans
                int MachtDesClans = Stamm.SummeDesMachtfaktors(stamm);
                Console.Write("" + stamm.Name + "(" + MachtDesClans + ")     " + stamm.GruendungNdK + " ndK          ");
                //Wenn wir den Stammesfuehrer nicht kennen wollen wir nicht einfach einen leeren Eintrag anzeigen, sondern etwas ausgeben.
                if (!string.IsNullOrEmpty(stamm.Stammeshaupt))
                {
                    Console.Write("" + stamm.Stammeshaupt + ", seit " + stamm.StammeshauptSeit);
                }else
                    Console.Write("unbekannter Stammesfuehrer");
                Console.Write("\n");
            }
            //Schauen wir mal, ob der Benutzer fertig ist, oder noch etwas erledigen möchte.
            ResetProgram();
        }

        //Einen Stamm editieren
        static void EditAClan()
        {
            Console.WriteLine("###      2: Staemme editieren        ###");
            ResetProgram();
        }

        //Alle Zwerge auflisten
        static void ShowDwarf()
        {
            Console.WriteLine("###      3: Zwerge anzeigen          ###");
            ResetProgram();
        }

        //Einen Zwerg editieren (Hinzufügen/Entfernen von Gegenstaenden) oder Zwerge erstellen etc (falls genug Zeit bleibt)
        static void EditDwarf()
        {
            Console.WriteLine("###      4: Zwerg editieren          ###");
            ResetProgram();
        }

        //Inventar
        static void EditInventory()
        {
            Console.WriteLine("###      5: Inventar editieren       ###");
            ResetProgram();
        }

        //Methode, um das Programm zu beenden oder fortzufuehren
        static void ResetProgram()
        {
            Console.WriteLine("Bitte geben Sie an, ob Sie...");
            Console.WriteLine("...eine andere Funktion ausfuehren moechten.  [1]");
            Console.WriteLine("...das Programm beenden moechten.             [2]");
            try
            {
                if (Int32.Parse(Console.ReadLine()) == 2)
                    running = false;
            }
            catch
            {
                Console.WriteLine("Ungültige Eingabe!");
                ResetProgram();
            }
             
            
        }



    }
}
