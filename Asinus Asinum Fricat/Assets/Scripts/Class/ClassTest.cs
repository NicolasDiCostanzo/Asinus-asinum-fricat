using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ClassTest
{
    public string titre;

    public List<string> list = new List<string>();
    public List<Champ> champs = new List<Champ>();

    public KeyValuePair<string, string> kpv = new KeyValuePair<string, string>("tto","caca");

    public Champ kp = new Champ(GeneralManager.Champs.Masculin, "toutou");


    public ClassTest(string titre)
    {
        this.titre = titre;
        this.list = new List<string>(){ "1", "2", "3" };

        champs.Add(new Champ(GeneralManager.Champs.Masculin, "test"));
    }
}

[Serializable]
public class Champ
{
    public GeneralManager.Champs Key;
    public string Value;
    public Champ(GeneralManager.Champs key, string value)
    {
        this.Key = key;
        this.Value = value;
    }
}
