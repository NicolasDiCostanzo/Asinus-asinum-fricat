using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class ListeDeMot
{
    public string titre;
    public string theme;
    public string commentaire;

    public List<Mot> mots = new List<Mot>();

    public ListeDeMot(string titre, string theme, string commentaire)
    {
        this.titre = titre;
        this.theme = theme;
        this.commentaire = commentaire;
    }

    public bool JsonSauvegarde()
    {
        string directory = GeneralManager._directory;
        string json = JsonUtility.ToJson(this, true);

        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        string fileDirectory = GeneralManager._directory + titre + ".txt";
        File.WriteAllText(fileDirectory, json);

        if (File.Exists(fileDirectory)) return true;

        return false;
    }

    public void DebugAfficherListe() { foreach (Mot mot in mots) mot.DebugAfficherMot(); }
}
