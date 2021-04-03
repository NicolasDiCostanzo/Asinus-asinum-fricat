using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;
using System;

[Serializable]
public class Mot
{
    public string traduction;
    public bool version;
    bool dejaInterroge;
    public List<KeyValuePair<GeneralManager.Champs, string>> champs = new List<KeyValuePair<GeneralManager.Champs, string>>();

    public Mot(string a_traduction)
    {
        dejaInterroge = false;
        champs.Add(new KeyValuePair<GeneralManager.Champs, string>(GeneralManager.Champs.Traduction, a_traduction));
    }

    public void DebugAfficherMot()
    {
        string debugAAfficher = "";

        for (int i = 0; i < champs.Count; i++)
            debugAAfficher += "--" + champs[i].Key + " " + champs[i].Value;

        Debug.Log("Version : " + version + " " + debugAAfficher);
    }

}
