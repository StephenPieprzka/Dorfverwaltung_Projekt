using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorfverwaltung
{
    class Program : IManagement
    {
        public int TotalTax()
        {
            int alleSteuern = 0;
            foreach (var Stamm in AlleClans)
            {
                alleSteuern += Stamm.Tax;
            }
            return alleSteuern;
        }
        public float BaseTax { get; set; }
        public List<Lebewesen> AllInhabitants()
        {
            return AlleBewohner;
        }
        public List<Lebewesen> AllDukes()
        {
            List<Lebewesen> allDukes = new List<Lebewesen>();
            foreach (var Stamm in AlleClans)
                allDukes.Add(AlleBewohner.Find(f => f.Name == Stamm.Stammeshaupt));
            return allDukes;
        }

        public static int SteuerBasisSatz = 2;
        //Initialisieren der Bewohnere und Clans
        static List<Lebewesen> AlleBewohner = new List<Lebewesen>();
        static Stamm Altobarden = new Stamm("Altobarden", "Zwerg", 1247, "Gimli", 25, new List<Lebewesen>() { });
        static Stamm Elbkbnechte = new Stamm("Elbknechte", "Zwerg", 1023, "", 0, new List<Lebewesen>() { });
        static Stamm Murkpeak = new Stamm("Murkpeak", "Elb", 0, "Iefyr", 12, new List<Lebewesen>() { });
        static Stamm Montzieu = new Stamm("Montzieu", "Elb", 0, "Malon", 104, new List<Lebewesen>() { });
        static List<Stamm> AlleClans = new List<Stamm>();


        static Zwerg Gimli = new Zwerg("Gimli", 140, "Altobarden", 0);
        static Zwerg Zwingli = new Zwerg("Zwingli", 70, "Altobarden", 0);
        static Zwerg Gumli = new Zwerg("Gumli", 163, "Elbknechte", 0);

        static Elb Elidyr = new Elb("Elidyr", 318, "Murkpeak", 0, true, 21.0f);
        static Elb Iefyr = new Elb("Iefyr", 214, "Murkpeak", 0, false, 84.0f);
        static Elb Vulas = new Elb("Vulas", 96, "Murkpeak", 0, false, 23.0f);
        static Elb Malon = new Elb("Malon", 592, "Montzieu", 0, false, 145.0f);


        //Bewohner fühlen sich ohne Waffen immer "nackt". Initialisieren wir also Waffen, damit die Bewohner diese nutzen können.
        static Gegenstand Axt01 = new Gegenstand("Axt", 12);
        static Gegenstand Schwert = new Gegenstand("Schwert", 15);
        static Gegenstand Axt02 = new Gegenstand("Axt", 17);
        static Gegenstand Zauberstab = new Gegenstand("Zauberstab", 45);
        static Gegenstand Streithammer = new Gegenstand("Streithammer", 15);

        //Bool, mit dem wir das Programm beenden können, falls gewünscht.
        static bool running = true;

        static void Main(string[] args)
        {
            Init();
            //Beginn der Benutzerinteraktion
            Console.WriteLine("#    Willkommen zur Königreichverwaltung.    #");
            RunProgramm();
        }

        static void RunProgramm()
        {
            int steuersatz;
            try
            {
                while (running)
                {
                    steuersatz = SteuerBasisSatz;
                    //Auswahl dem Nutzer überlassen
                    Console.WriteLine("###  Bitte wählen Sie eine Aktion    ###");
                    Console.WriteLine("###      0: Übersichtsanzeige        ###");
                    Console.WriteLine("###      1: Staemme anzeigen         ###");
                    Console.WriteLine("###      2: Staemme editieren        ###");
                    Console.WriteLine("###      3: Bewohner anzeigen        ###");
                    Console.WriteLine("###      4: Bewohner editieren       ###");
                    Console.WriteLine("###      5: Inventar editieren       ###");
                    Console.WriteLine("###      6: Steuersatz editieren     ###");
                    Console.WriteLine("###      9: Programm beenden         ###");
                    //Aufruf der passenden Methode basierend auf Nutzerinput
                    switch (Int32.Parse(Console.ReadLine()))
                    {
                        case 0: Console.Clear(); ShowOverView(); break;
                        case 2: Console.Clear(); EditAClan(); break;
                        case 3: Console.Clear(); ShowCitizen(); break;
                        case 4: Console.Clear(); EditCitizen(); break;
                        case 5: Console.Clear(); EditInventory(); break;
                        case 6: Console.Clear(); EditTaxation(); break;
                        case 9: running = false; break;
                        case 42: Console.WriteLine("Das ist hier nicht die Antwort!"); break;
                        default: Console.Clear(); ShowAllClans(); break;
                    }

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ungültige Eingabe - Bitte versuchen Sie es erneut!");
                RunProgramm();
            }


        }
        static void ShowOverView()
        {
            int gesamtsteuerSatz = 0;
            foreach (var Stamm in AlleClans)
            {
                gesamtsteuerSatz += Stamm.Tax;
            }
            Console.WriteLine("###      0: Übersichtsanzeige        ###");
            Console.WriteLine("\n");
            Console.WriteLine("Gesamtsteuereinnahmen: " + gesamtsteuerSatz + ".00");
            Console.WriteLine("Steuereinnahmen nach Einwohner:");
            int _anzahlBewohner = 0;
            gesamtsteuerSatz = 0;
            foreach (var Einwohner in AlleBewohner)
            {
                _anzahlBewohner += 1;
                string istStammesfuehrer = "";
                if (Einwohner.Name.Equals(AlleClans.Find(f => f.Name == Einwohner.Stamm).Stammeshaupt))
                {
                    istStammesfuehrer = "[*]";
                }
                if (Einwohner.Spezies.Equals("Zwerg"))
                {
                    int bewohnerSteuersatz = Einwohner.Machtfaktor * SteuerBasisSatz;
                    gesamtsteuerSatz += bewohnerSteuersatz;
                    Console.WriteLine(istStammesfuehrer + Einwohner.Name + "(Zwerg): " + bewohnerSteuersatz + ".00");
                }                
                else
                {
                    Elb Bewohner = (Elb)Einwohner;
                    int bewohnerSteuersatz = (int)(Einwohner.Alter / SteuerBasisSatz + Bewohner.Haarlaenge);
                    gesamtsteuerSatz += bewohnerSteuersatz;
                    Console.WriteLine(istStammesfuehrer + Einwohner.Name + "(Elb): " + bewohnerSteuersatz + ".00");
                }
            }
            Console.WriteLine("Durchschnittssteuern: " + gesamtsteuerSatz / _anzahlBewohner + "(" + gesamtsteuerSatz + "/" + _anzahlBewohner + ")");
            ResetProgram();
        }

        //Alle Staemme anzeigen
        static void ShowAllClans()
        {
            Console.WriteLine("###      1: Staemme anzeigen         ###");
            Console.WriteLine("Stammname        Stammesgründung     Stammesfuehrer");
            //Schleife für alle Staemme
            foreach (var stamm in AlleClans)
            {
                //Berechnung des Machtfaktors des Clans
                int MachtDesClans = Stamm.SummeDesMachtfaktors(stamm);
                Console.Write("" + stamm.Name + "(" + MachtDesClans + ")     " + stamm.GruendungNdK + "ndK          ");
                //Wenn wir den Stammesfuehrer nicht kennen wollen wir nicht einfach einen leeren Eintrag anzeigen, sondern etwas ausgeben.
                if (!string.IsNullOrEmpty(stamm.Stammeshaupt))
                {
                    Console.Write("" + stamm.Stammeshaupt + ", seit " + stamm.StammeshauptSeit + " Jahren");
                }
                else
                    Console.Write("unbekannter Stammesfuehrer");
                Console.WriteLine("\n Besteuerung: " + (MachtDesClans * SteuerBasisSatz));
            }
            //Schauen wir mal, ob der Benutzer fertig ist, oder noch etwas erledigen möchte.
            ResetProgram();
        }

        //Einen Stamm editieren
        static void EditAClan()
        {
            Console.WriteLine("###      2: Staemme editieren        ###");
            Console.WriteLine("Welchen Stamm möchten Sie editieren?");
            int countOfClans = 0;
            int curremtstamm = 0;
            foreach (var stamm in AlleClans)
            {
                countOfClans += 1;
                //Berechnung des Machtfaktors des Clans
                int MachtDesClans = Stamm.SummeDesMachtfaktors(stamm);
                Console.Write("" + countOfClans + " :  " + stamm.Name + "(" + MachtDesClans + ")\n");
                //Wenn wir den Stammesfuehrer nicht kennen wollen wir nicht einfach einen leeren Eintrag anzeigen, sondern etwas ausgeben.
            }
            try
            {
                //Auswahl des Nutzers übernehmen
                curremtstamm = (int.Parse(Console.ReadLine()) - 1);
            }
            catch
            {
                //Bei Problem dem Nutzer eine zweite Eingabe zur Verfügung stellen
                Console.WriteLine("Bitte geben Sie eine gültige Stammeszahl an ('1' - '" + AlleClans.Count() + "')!");
                int stamm = int.Parse(Console.ReadLine());
            }
            //Namensänderung des Stammes
            Console.WriteLine("Namensänderung: " + AlleClans[curremtstamm].Name + " - leer lassen um nicht zu verändern.");
            string newName = Console.ReadLine();
            if (newName.Length > 0)
            {
                //Wenn der Name geändert wird, brauchen die Bewohnere eine Benachrichtigung, sonst wird das nächste Stammestreffen peinlich für sie.
                foreach (var bewohner in AlleBewohner)
                {
                    if (bewohner.Stamm.Equals(AlleClans[curremtstamm].Name))
                    {
                        bewohner.Stamm = newName;
                    }
                }
                //Namen des Stamms ändern
                AlleClans[curremtstamm].Name = newName;
            }

            //Gründungszeit ändern
            Console.WriteLine("Gründung: " + AlleClans[curremtstamm].GruendungNdK + " - leer lassen um nicht zu verändern.");
            string newFounding = Console.ReadLine();
            if (!string.IsNullOrEmpty(newFounding))
                if (int.Parse(newFounding) > 0)
                    AlleClans[curremtstamm].GruendungNdK = int.Parse(newFounding);


            //Bewohner in Charge ändern
            Console.WriteLine("Führungsänderung (Bewohner): " + AlleClans[curremtstamm].Stammeshaupt + " - leer lassen um nicht zu verändern.");
            string newLeader = Console.ReadLine();
            bool fuehrerGefunden = false;
            if (newLeader.Length > 0)
            {
                foreach (var bewohner in AlleBewohner)
                {
                    if (AlleClans[curremtstamm].Mitglieder.Contains(bewohner))
                    {
                        AlleClans[curremtstamm].Stammeshaupt = newLeader;
                        fuehrerGefunden = true;
                    }
                    //Wenn kein Bewohner passt, gibt es diesen (noch) nicht
                }
                if (!fuehrerGefunden)
                {
                    Console.WriteLine("Dieser Bewohner ist nicht einmal im Stamm - netter Versuch!");
                }

            }

            //Zeit der Machtübernahme ändern, falls Führung vorhanden - ansonsten übersprungen
            if (AlleClans[curremtstamm].Stammeshaupt != "")
            {
                Console.WriteLine("Führungsänderung (Zeit in Jahren): " + AlleClans[curremtstamm].StammeshauptSeit + " - leer lassen um nicht zu verändern.");
                string newLeaderSince = Console.ReadLine();
                try
                {
                    if (!string.IsNullOrEmpty(newLeaderSince))
                        if (int.Parse(newLeaderSince) > 0)
                            AlleClans[curremtstamm].StammeshauptSeit = int.Parse(newLeaderSince);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ungültige Eingabe");
                    throw;
                }
            }
            ResetProgram();
        }

        //Alle Bewohnere auflisten
        static void ShowCitizen()
        {
            Console.WriteLine("###      3: Bewohner anzeigen          ###");
            foreach (var bewohner in AlleBewohner)
            {
                //Berechnung des Machtfaktors des Clans
                int MachtDesBewohners = bewohner.Machtfaktor;
                string stammesfuehrer = "";
                string stammesfuehrervon = "";
                int stammesfuehrerseit = 0;
                Console.Write(bewohner.Spezies + " - " + bewohner.Name + "(" + MachtDesBewohners + ")     " + bewohner.Alter + " Jahre alt          ");
                //Wenn wir den Stammesfuehrer nicht kennen wollen wir nicht einfach einen leeren Eintrag anzeigen, sondern etwas ausgeben.
                foreach (var stamm in AlleClans)
                {
                    //Erfassen des Stammes, falls der Bewohner Mitglied ist
                    if (stamm.Mitglieder.Contains(bewohner))
                    {
                        stammesfuehrer = stamm.Stammeshaupt;
                        stammesfuehrervon = stamm.Name;
                        stammesfuehrerseit = stamm.StammeshauptSeit;
                    }
                }
                //Wenn der Stamm vom Bewohner geführt wird, geben wir dies aus, ansonsten wo der Bewohner Mitglied ist
                if (stammesfuehrer.Equals(bewohner.Name))
                {
                    Console.Write("" + bewohner.Name + " führt den Clan " + stammesfuehrervon + " seit " + stammesfuehrerseit + " Jahren.");
                }
                else
                    Console.Write("Mitglied von " + stammesfuehrervon);
                //Für den König besonder interessant: wie viel Steuern zahlt der Bewohner potentiell?
                Console.Write("\n Besteuerung: " + (MachtDesBewohners * SteuerBasisSatz) + "\n");

                if (bewohner.Spezies.Equals("Zwerg"))
                {
                    Zwerg zwerg = (Zwerg)bewohner;
                    foreach (var item in zwerg.Inventar)
                    {
                        Console.Write("" + item.Name + "(" + item.MagieWert + "), ");
                    }
                }
                else if (bewohner.Spezies.Equals("Elb"))
                {
                    Console.Write("Elben haben nur ihre Haare als Waffe.");
                }
                Console.Write("\n");
                Console.WriteLine("");
            }
            ResetProgram();

        }

        //Einen Bewohner editieren (Hinzufügen/Entfernen von Gegenstaenden) oder Bewohnere erstellen etc (falls genug Zeit bleibt)
        static void EditCitizen()
        {
            Console.WriteLine("###      4: Bewohner editieren          ###");
            int currentBewohner = 0;
            foreach (var bewohner in AlleBewohner)
            {
                currentBewohner += 1;
                //Auflistung aller Bewohnere
                Console.Write(currentBewohner + ": " + bewohner.Name + "(" + bewohner.Machtfaktor + ")     " + bewohner.Alter + " Jahre alt          ");
                //Alle Bewohnere sind Ziele für Steuern - Inventarauswertung
                if (bewohner.Spezies.Equals("Zwerg"))
                {
                    Zwerg zwerg = (Zwerg)bewohner;
                    foreach (var item in zwerg.Inventar)
                    {
                        Console.Write("" + item.Name + "(" + item.MagieWert + "), ");
                    }
                }
                else if (bewohner.Spezies.Equals("Zwerg"))
                {
                    Elb elb = (Elb)bewohner;
                    Console.Write("Haupthaar (" + elb.Haarlaenge + ")");
                }
                Console.Write("\n");
            }
            //Bewohner auswählen
            Console.WriteLine("###      Bitte Bewohner auswählen       ###");
            Console.WriteLine("###      'Add' für neuen Bewohner       ###");
            string selection = "";
            Lebewesen bewohnerToEdit;
            try
            {
                selection = Console.ReadLine();
                if (!selection.Equals("Add"))
                {
                    currentBewohner = (int.Parse(selection) - 1);
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Fehlerhafte Eingabe - nochmal Versuchen!");
                EditCitizen();
            }
            if (selection.Equals("Add"))
            {
                bewohnerToEdit = new Zwerg("", 0, "", 0);
                AlleBewohner.Add(bewohnerToEdit);
            }
            else
                bewohnerToEdit = AlleBewohner[currentBewohner];
            //Namensänderung des Bewohners
            Console.WriteLine("Namensänderung: " + bewohnerToEdit.Name + " - leer lassen um nicht zu verändern.");
            string newName = Console.ReadLine();
            if (newName.Length > 0)
                bewohnerToEdit.Name = newName;

            //Alter ändern
            Console.WriteLine("Alter: " + bewohnerToEdit.Alter + " - leer lassen um nicht zu verändern.");
            string newAge = Console.ReadLine();
            if (!string.IsNullOrEmpty(newAge))
                if (int.Parse(newAge) > 0)
                    bewohnerToEdit.Alter = int.Parse(newAge);


            //Bewohner in anderen Stamm setzen
            Console.WriteLine("Stammesänderung: " + bewohnerToEdit.Stamm + " - leer lassen um nicht zu verändern.");
            string newStamm = Console.ReadLine();
            bool newStammFound = false;
            bool hadnoStamm = true;
            if (newStamm.Length > 0)
            {
                //Suche nach altem Stamm
                foreach (var stamm in AlleClans)
                {
                    if (stamm.Name.Equals(bewohnerToEdit.Stamm))
                    {
                        hadnoStamm = false;
                        //Abfrage, ob der Bewohner Stammesoberhaupt ist
                        if (!stamm.Stammeshaupt.Equals(bewohnerToEdit.Name))
                        {
                            //Bewohner aus altem Stamm entfernen
                            stamm.RemoveBewohner(stamm, bewohnerToEdit);
                            bewohnerToEdit.Stamm = newStamm;
                            //Neuen Stamm suchen
                            foreach (var fancyStamm in AlleClans)
                            {
                                if (fancyStamm.Name.Equals(newStamm))
                                {
                                    //Bewohner eintragen
                                    newStammFound = true;
                                    stamm.AddBewohner(fancyStamm, bewohnerToEdit);
                                }
                            }
                            if (!newStammFound)
                            {
                                //Stamm nicht gefunden, Bewohner in alten Stamm zurücksetzen
                                Console.WriteLine("Stamm nicht gefunden, Bewohner verbleibt in altem Stamm!");
                                stamm.AddBewohner(stamm, bewohnerToEdit);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Bitte die Stammesführung erst ändern. Der Stammesführer kann den Stamm nicht verlassen!");
                        }
                    }
                }
                if (hadnoStamm)
                {
                    foreach (var stamm in AlleClans)
                        if (stamm.Name.Equals(newStamm))
                            stamm.AddBewohner(stamm, bewohnerToEdit);
                }
            }
            ResetProgram();
        }

        //Inventar
        static void EditInventory()
        {
            Console.WriteLine("###      5: Inventar editieren       ###");
            //Ich bin faul, kopiere also die Auswahl des Bewohners vom Bewohner editieren
            int currentBewohner = 0;
            foreach (var bewohner in AlleBewohner)
            {
                currentBewohner += 1;
                //Auflistung aller Bewohnere
                Console.Write(currentBewohner + ": " + bewohner.Name + "(" + bewohner.Machtfaktor + ")     " + bewohner.Alter + " Jahre alt          ");
                //Alle Bewohnere sind Ziele für Steuern - Inventarauswertung
                if (bewohner.Spezies.Equals("Zwerg"))
                {
                    Zwerg zwerg = (Zwerg)bewohner;
                    foreach (var item in zwerg.Inventar)
                    {
                        Console.Write("" + item.Name + "(" + item.MagieWert + "), ");
                    }
                }
                else if (bewohner.Spezies.Equals("Elb"))
                {
                    Elb elb = (Elb)bewohner;
                    Console.Write("Elben haben nur ihre Haare als Waffe. Länge: " + elb.Haarlaenge);
                }
                Console.Write("\n");
            }
            //Bewohner auswählen
            Console.WriteLine("###      Bitte Bewohner auswählen       ###");
            try
            {
                //Eingabe des Benutzers
                currentBewohner = (int.Parse(Console.ReadLine()) - 1);
            }
            //Eingabe falsch formatiert
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Fehlerhafte Eingabe - nochmal Versuchen!");
                EditInventory();
            }
            //Bewohner Veriable - das andere geht zwar auch jedesmal, ist aber mehr schreibarbeit
            if (AlleBewohner[currentBewohner].Spezies.Equals("Zwerg"))
            {
                Zwerg bewohnerToEdit = (Zwerg)AlleBewohner[currentBewohner];
                Console.Clear();
                //Alle Inventarelemente darstellen
                foreach (var item in bewohnerToEdit.Inventar)
                {
                    Console.Write("" + item.Name + "(" + item.MagieWert + "), ");
                    Console.Write("\n");
                }
                //Nutzer entscheiden lassen, ob er etwas bearbeiten möchte
                Console.WriteLine("Was möchten Sie tun?");
                Console.WriteLine("1: Gegenstand hinzufügen?");
                Console.WriteLine("2: Gegenstand entfernen?");
                Console.WriteLine("3: Nichts tun?");
                int todo = 0;
                try
                {
                    todo = (int.Parse(Console.ReadLine()) - 1);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Fehlerhafte Eingabe - nochmal Versuchen!");
                    EditInventory();
                }
                //Auswahl der Fälle mal per IF - nicht wie vorher immer mit switch case
                //Auswahl 1 - hinzufügen
                if (todo == 0)
                {
                    //Neuer Gegenstand wird durch Nutzer erstellt
                    Console.WriteLine("Gegenstand hizufügen:");
                    Console.WriteLine("Bitte geben Sie dem Gegenstand einen Namen");
                    string name = Console.ReadLine();
                    Console.WriteLine("Bitte geben Sie dem Gegenstand einen Machtfaktor (ganzzahl positiv)");
                    int machtfaktor = int.Parse(Console.ReadLine());
                    //Und dann dem Bewohner gegeben.
                    bewohnerToEdit.AddItem(bewohnerToEdit, new Gegenstand(name, machtfaktor));
                }
                //Auswahl 2 - entfernen
                else if (todo == 1)
                {
                    //Die Liste nochmals darstellen, um dem Nutzer die Auswahl zu erleichtern
                    int currentItem = 0;
                    foreach (var item in bewohnerToEdit.Inventar)
                    {
                        currentItem += 1;
                        Console.Write(currentItem + ": " + item.Name + "(" + item.MagieWert + "), ");
                        Console.Write("\n");
                    }
                    //Nutzer wählt den alten Ramsch zum entfernen aus
                    Console.WriteLine("Welchen Gegenstand möchten Sie entfernen?");
                    currentItem = (int.Parse(Console.ReadLine()) - 1);
                    //Ramsch wird entfernt
                    bewohnerToEdit.RemoveItem(bewohnerToEdit, bewohnerToEdit.Inventar[currentItem]);
                    Console.WriteLine("Thy dirty deed be done!");
                }
                //Auswahl 3 - nichts tun
                else if (todo == 2)
                {
                    Console.WriteLine("Nichts bearbeitet.");
                }
                else
                {
                    Console.WriteLine("Diese Option besteht nicht!");
                }
            }

            ResetProgram();
        }
        static void EditTaxation()
        {
            Console.WriteLine("###      6: Besteuerung editieren    ###");
            Console.Write("Momentane Besteuerung: " + SteuerBasisSatz + ". Möchten Sie den Steuersatz anpassen? [J/n]");
            switch (Console.ReadLine())
            {
                case "J": EditSteuerBasisSatz(); break;
                case "j": EditSteuerBasisSatz(); break;
                case "N": return;
                case "n": return;
                default: EditSteuerBasisSatz(); break;
            }
        }

        static void EditSteuerBasisSatz()
        {
            Console.Write("Bitte geben Sie den neuen Steuerbasissatz an:");
            try
            {
                SteuerBasisSatz = Int32.Parse(Console.ReadLine());
                Console.Write("Der Basissteuersatz wurde geändert.");
                ResetProgram();
            }
            catch (Exception)
            {
                Console.Write("Bitte geben Sie den Steuerbasissatz als Integer [0..999] an:");
                EditSteuerBasisSatz();
            }

        }

        static void Init()
        {
            SteuerBasisSatz = 2;
            //Ausrüsten der Bewohnere für Raids & Co
            Gimli.Inventar.Add(Axt01);
            Gimli.Inventar.Add(Schwert);
            Zwerg.UpdateMachtfaktor(Gimli);
            Gumli.Inventar.Add(Axt02);
            Zwerg.UpdateMachtfaktor(Gumli);
            Zwingli.Inventar.Add(Zauberstab);
            Zwingli.Inventar.Add(Streithammer);
            Zwerg.UpdateMachtfaktor(Zwingli);
            Elb.UpdateMachtfaktor(Elidyr);
            Elb.UpdateMachtfaktor(Iefyr);
            Elb.UpdateMachtfaktor(Vulas);
            Elb.UpdateMachtfaktor(Malon);

            //Bewohnere sind keine Einzelkämpfer
            Altobarden.Mitglieder.Add(Gimli);
            Altobarden.Mitglieder.Add(Zwingli);
            Elbkbnechte.Mitglieder.Add(Gumli);

            Murkpeak.Mitglieder.Add(Elidyr);
            Murkpeak.Mitglieder.Add(Iefyr);
            Murkpeak.Mitglieder.Add(Vulas);
            Montzieu.Mitglieder.Add(Malon);
            //Hinzufügen der Stämme zu einer Liste
            AlleClans.Add(Altobarden);
            AlleClans.Add(Elbkbnechte);
            AlleClans.Add(Murkpeak);
            AlleClans.Add(Montzieu);
            //Hinzufügen der Bewohnere zu einer Liste
            AlleBewohner.Add(Gimli);
            AlleBewohner.Add(Gumli);
            AlleBewohner.Add(Zwingli);
            AlleBewohner.Add(Elidyr);
            AlleBewohner.Add(Iefyr);
            AlleBewohner.Add(Vulas);
            AlleBewohner.Add(Malon);
        }

        //Methode, um das Programm zu beenden oder fortzufuehren
        static void ResetProgram()
        {
            Console.WriteLine("Funktionsende - Tasteneingabe um fortzufahren");
            Console.ReadKey();
            Console.Clear();
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
            Console.Clear();

        }
        //Endlich fertig...
    }
}

