//Ich musste diese using Verweise hinzufügen, ansonsten hätte ich die Aufrufe für string und List ändern müssen.
using System;
using System.Collections.Generic;
/// <summary>
/// Contains the nessary informations and methods about one Inhabitant for the management
/// </summary>
namespace Dorfverwaltung
{
    public interface IInhabitant
    {

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        String Name { get; }

        /// <summary>
        /// Return the total tax for this Inhabitant
        /// </summary>
        /// <value>The tax.</value>
        int Tax { get; }
    }

    /// <summary>
    /// Contains the nessary informations and methods about one Duke for the management
    /// </summary>
    public interface IDuke : IInhabitant
    {

        /// <summary>
        /// Receive the information since how many years he/she is the leader.
        /// </summary>
        /// <value>The leader since.</value>
        int LeaderSince { get; }
    }

    /// <summary>
    /// Management the tax
    /// </summary>
    public interface IManagement
    {
        /// <summary>
        /// Return the complete Tax amount
        /// </summary>
        /// <returns>The tax amount.</returns>
        int TotalTax();

        /// <summary>
        /// Sets the base tax for the calculation 
        /// </summary>
        /// <value>The dwarf tax.</value>
        float BaseTax { set; }

        /// <summary>
        /// Return all inhabitants.
        /// </summary>
        /// <returns>The inhabitants.</returns>
        List<Lebewesen> AllInhabitants();

        /// <summary>
        /// Return all dukes.
        /// </summary>
        /// <returns>The dukes.</returns>
        List<Lebewesen> AllDukes();

    }
}