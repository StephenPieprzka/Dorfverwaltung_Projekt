using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *################################################################
 * 
 *  Diese Datei enthält die Klasse Gegenstand.
 *  
 *################################################################
 */

namespace Dorfverwaltung
{
    public class Gegenstand
    {
        //Jeder Gegenstand besitzt einen Namen.
        public string Name { get; set; }
        //Jeder Gegenstand besitzt einen Magiewert.
        public int MagieWert { get; set; }

        //Konstuktor, um einen Gegenstand zu erzeugen.
        public Gegenstand(string name, int magieWert)
        {
            //Hier nutzen wir Parameter, um diese dem neuen Gegenstand als Werte zu geben.
            Name = name;
            MagieWert = magieWert;
        }
    }
}
