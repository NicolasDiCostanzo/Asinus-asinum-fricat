using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneralManager;
using System;

public class Adjectif1 : Mot
{
    public Adjectif1(string a_masculin, string a_feminin, string a_neutre, string a_traduction)
        :base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Masculin, a_masculin));
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Feminin, a_feminin));
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Neutre, a_neutre));
    }
}
