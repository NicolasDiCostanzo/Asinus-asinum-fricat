using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text.Json;
using TMPro;
public class AfficherListes : MonoBehaviour
{
    [SerializeField] GameObject affichageListePrefab;

    private void Start()
    {
        Transform parent = GameObject.Find("Zone affichage").transform;
        string directory = GeneralManager.directory;

        ListeDeMot _liste = new ListeDeMot("titre", "theme", "comm");
        AfficherListe(_liste, parent);
        ListeDeMot _liste2 = new ListeDeMot("titre2", "theme3", "commentaire");
        AfficherListe(_liste2, parent);

        //if (Directory.Exists(directory))
        //{

        //    foreach (string file in Directory.GetFiles(directory))
        //    {
        //        string listeJson = File.ReadAllText(file);

        //        ListeDeMot _liste = new ListeDeMot("titre", "theme", "comm");

        //        AfficherListe(_liste, parent);
        //    }

        //}
    }

    void AfficherListe(ListeDeMot a_liste, Transform a_parent)
    {
        GameObject afficherListe_instance = Instantiate(affichageListePrefab);
        afficherListe_instance.transform.SetParent(a_parent, false);
        afficherListe_instance.name = a_liste.titre;
        afficherListe_instance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = a_liste.titre;
        afficherListe_instance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = a_liste.theme;
        afficherListe_instance.GetComponent<AfficherCommentaire>().commentaire = a_liste.commentaire;
    }
}
