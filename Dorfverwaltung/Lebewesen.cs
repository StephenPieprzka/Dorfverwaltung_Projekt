using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 *################################################################
 * 
 *  Diese Datei enthält die Klasse Lebewesen.
 *  
 *################################################################
 */

namespace Dorfverwaltung
{
    public abstract class Lebewesen
    {
        //Jedes Lebewesen in dieser Anwendung sollte einen Namen haben.
        public string Name { get; set; }
        //Jedes Lebewesen gehört einer Spezies an.
        public string Spezies { get; set; }
        //Jedes Lebewesen hat ein Alter.
        public int Alter { get; set; }
        //Jedes Lebewesen ist in einem Stamm.
        public string Stamm { get; set; }
        //Jedes Lebewesen, so niedrig dieser auch sei, besitzt einen Machtfaktor.
        public int Machtfaktor { get; set; }
    }
}
