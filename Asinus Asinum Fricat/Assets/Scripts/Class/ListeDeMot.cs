using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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

    public void JsonSauvegarde()
    {
        string directory = GeneralManager.directory;

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };

        string json = JsonUtility.ToJson(this, true);

        if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        File.WriteAllText(directory + titre + ".txt", json);
    }

    public void DebugAfficherListe() { foreach (Mot mot in mots) mot.DebugAfficherMot(); }
}
