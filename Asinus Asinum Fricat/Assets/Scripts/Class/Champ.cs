using System;
using System.Collections.Generic;

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
