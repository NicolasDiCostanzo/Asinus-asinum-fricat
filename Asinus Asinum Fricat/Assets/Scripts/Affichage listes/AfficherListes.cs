using System.IO;
using TMPro;
using UnityEngine;
public class AfficherListes : MonoBehaviour
{
    [SerializeField] GameObject affichageListePrefab;

    private void Start()
    {
        Transform parent = GameObject.Find("Zone affichage").transform;
        string directory = GeneralManager.directory;

        if (Directory.Exists(directory))
        {
            foreach (string file in Directory.GetFiles(directory))
            {
                string listeJson = File.ReadAllText(file);
                ListeDeMot _liste = JsonUtility.FromJson<ListeDeMot>(listeJson);
                AfficherListe(_liste, parent);
            }

        }
    }

    void AfficherListe(ListeDeMot a_liste, Transform a_parent)
    {
        GameObject afficherListe_instance = Instantiate(affichageListePrefab);

        afficherListe_instance.transform.SetParent(a_parent, false);
        afficherListe_instance.name = a_liste.titre;

        afficherListe_instance.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = a_liste.titre;
        afficherListe_instance.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = a_liste.theme;

        afficherListe_instance.GetComponent<AssocierStructureListe>().listeAssociee = a_liste;
    }
}
