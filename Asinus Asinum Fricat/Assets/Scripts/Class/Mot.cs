using System;
using System.Collections.Generic;
using UnityEngine;
using static GeneralManager;

[Serializable]
public class Mot
{
    public bool version;
    public TypeDeMot type;

    public string commentaire;
    public bool dejaInterroge { get; set; }
    public List<Champ> champs = new List<Champ>();

    public Mot(string a_traduction, string a_commentaire, bool version)
    {
        dejaInterroge = false;

        this.version = version;
        this.commentaire = a_commentaire;

        champs.Add(new Champ(Champs.Traduction, a_traduction));
    }

    public Mot() { dejaInterroge = false; }

    public void DebugAfficherMot()
    {
        string debugAAfficher = type + " :\n";

        for (int i = 0; i < champs.Count; i++) debugAAfficher += champs[i].Key + "->" + champs[i].Value + "\n";

        Debug.Log(debugAAfficher + "Version : " + version + "\nCommentaire : " + commentaire);
    }

}
