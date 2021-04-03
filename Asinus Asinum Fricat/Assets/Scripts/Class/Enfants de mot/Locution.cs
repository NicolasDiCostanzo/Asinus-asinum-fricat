using System;
using System.Collections.Generic;
using static GeneralManager;


[Serializable]
public class Locution : Mot
{
    public Locution(string a_locution, string a_traduction)
        : base(a_traduction)
    {
        champs.Insert(0, new KeyValuePair<Champs, string>(Champs.Locution, a_locution));
    }
}
