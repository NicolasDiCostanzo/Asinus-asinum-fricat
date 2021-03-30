using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verbe : Mot
{
    public Verbe(string a_nominatif, string a_genitif, string a_genre, string a_traduction)
    : base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Present1, a_nominatif));
        champs.Insert(1, new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Present2, a_genitif));
        champs.Insert(2, new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Infinitif, a_genre));
        champs.Insert(2, new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Imparfait, a_genre));
        champs.Insert(2, new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Supin, a_genre));
    }
}
