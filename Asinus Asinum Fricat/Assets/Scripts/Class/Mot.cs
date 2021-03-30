using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class Mot
{
    public string traduction;
    public bool version;
    public List<KeyValuePair<GeneralManager.Champs, string>> champs = new List<KeyValuePair<GeneralManager.Champs, string>>();

    public Mot(string a_traduction)
    {
        champs.Add(new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Traduction, a_traduction));
    }

}
