using System;
using System.Collections.Generic;
using static GeneralManager;

[Serializable]
public class Verbe : Mot
{
    /// <summary>
    /// Present1, Present2, Infinitif, Imparfait, Supin,
    /// </summary>
    /// <param name="a_present1"></param>
    /// <param name="a_genitif"></param>
    /// <param name="a_genre"></param>
    /// <param name="a_traduction"></param>
    public Verbe(string a_present1, string a_present2, string a_infinitif, string a_imparfait, string a_supin, string a_traduction)
    : base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Present1, a_present1));
        champs.Insert(1, new KeyValuePair<Champs, string>(Champs.Present2, a_present2));
        champs.Insert(2, new KeyValuePair<Champs, string>(Champs.Infinitif, a_infinitif));
        champs.Insert(3, new KeyValuePair<Champs, string>(Champs.Imparfait, a_imparfait));
        champs.Insert(4, new KeyValuePair<Champs, string>(Champs.Supin, a_supin));
    }
}
