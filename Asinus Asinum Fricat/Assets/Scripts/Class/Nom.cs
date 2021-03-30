using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Nom : Mot
{
    //nominatif, genitif, genre, traduction

    //Nom nom = new Nom("Aquqsda", "Aquae", "Aquaum", "Eau");
    //nom.champs[Champs.Nominatif] = "nouveau";

    public new Dictionary<GeneralManager.Champs, string> champs = new Dictionary<GeneralManager.Champs, string>();

    public Nom(string a_nominatif, string a_genitif, string a_genre, string a_traduction)
    {
        champs.Add(GeneralManager.Champs.Nominatif, a_nominatif);
        champs.Add(GeneralManager.Champs.Genitif, a_genitif);
        champs.Add(GeneralManager.Champs.Genre, a_genre);
        traduction = a_traduction;
    }

    /// <summary>
    /// Item1 = nominatif,
    /// Item2 = genitif,
    /// Item3 = genre,
    /// Item4 = traduction
    /// </summary>
    /// <returns></returns>
    public Tuple<string, string, string, string> RetournerTousChamps()
    {
        string nominatif = champs[GeneralManager.Champs.Nominatif];
        string genitif = champs[GeneralManager.Champs.Genitif];
        string genre = champs[GeneralManager.Champs.Genre];

        return Tuple.Create(nominatif, genitif, genre, traduction);
    }

    //public string RetournerNominatif() { return champs[GeneralManager.Champs.Nominatif]; }
    //public string RetournerGenitif() { return champs[GeneralManager.Champs.Genitif]; }
    //public string RetournerGenre() { return champs[GeneralManager.Champs.Genre]; }
    //public string RetournerTraduction() { return traduction; }

}
