using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Mot
{
    public bool version { get; set; }
    public bool dejaInterroge { get; set; }

    public List<KeyValuePair<GeneralManager.Champs, string>> champs = new List<KeyValuePair<GeneralManager.Champs, string>>();

    public Mot(string a_traduction)
    {
        dejaInterroge = false;
        champs.Add(new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Traduction, a_traduction));
    }

    public Mot() { dejaInterroge = false; }

    public void DebugAfficherMot()
    {
        string debugAAfficher = GetType().UnderlyingSystemType.Name + " :\n";

        for (int i = 0; i < champs.Count; i++) debugAAfficher += champs[i].Key + "->" + champs[i].Value + "\n";

        Debug.Log(debugAAfficher + "Version : " + version + " ");
    }

}
