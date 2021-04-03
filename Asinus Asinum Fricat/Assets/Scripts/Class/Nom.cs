using System;
using System.Collections.Generic;
using static GeneralManager;

[Serializable]
public class Nom : Mot
{
    /// <summary>
    ///  nominatif, genitif, genre, traduction
    /// </summary>
    /// <param name="a_nominatif"></param>
    /// <param name="a_genitif"></param>
    /// <param name="a_genre"></param>
    /// <param name="a_traduction"></param>
    /// 
    public Nom(string a_nominatif, string a_genitif, string a_genre, string a_traduction)
        : base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Nominatif, a_nominatif));
        champs.Insert(1, new KeyValuePair<Champs, string>(Champs.Genitif, a_genitif));
        champs.Insert(2, new KeyValuePair<Champs, string>(Champs.Genre, a_genre));
    }



    /// <summary>
    /// Item1 = nominatif,
    /// Item2 = genitif,
    /// Item3 = genre,
    /// Item4 = traduction
    /// </summary>
    /// <returns></returns>
    //public Tuple<string, string, string, string> RetournerTousChamps()
    //{
    //    string nominatif = champs[GeneralManager.Champs.Nominatif];
    //    string genitif = champs[GeneralManager.Champs.Genitif];
    //    string genre = champs[GeneralManager.Champs.Genre];

    //    return Tuple.Create(nominatif, genitif, genre, traduction);
    //}

    //public string RetournerNominatif() { return champs[GeneralManager.Champs.Nominatif]; }
    //public string RetournerGenitif() { return champs[GeneralManager.Champs.Genitif]; }
    //public string RetournerGenre() { return champs[GeneralManager.Champs.Genre]; }
    //public string RetournerTraduction() { return traduction; }

}
