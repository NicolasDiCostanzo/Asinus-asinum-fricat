using System.IO;
using UnityEngine;

public class SupprimerListe : MonoBehaviour
{
    [HideInInspector] public ListeDeMot listeAssociee;
    [HideInInspector] public GameObject listeGO;

    public void f_SupprimerListe()
    {
        string directory = GeneralManager._directory;
        string titreListe = listeAssociee.titre;

        Debug.Log(titreListe);

        File.Delete(directory + titreListe + ".txt");

        if (GameObject.Find("Commentaire(Clone)")) Destroy(GameObject.Find("Commentaire(Clone)"));

        Destroy(listeGO);
    }
}
