using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static GeneralManager;

public class Adjectif2 : Mot
{
    public Adjectif2(string a_masculin, string a_feminin, string a_neutre, string a_genitif, string a_traduction)
        : base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Masculin, a_masculin));
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Feminin, a_feminin));
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Neutre, a_neutre));
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Genitif, a_genitif));
    }
}