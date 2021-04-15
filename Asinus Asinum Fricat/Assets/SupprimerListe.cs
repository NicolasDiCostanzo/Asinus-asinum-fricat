using System.IO;
using UnityEngine;

public class SupprimerListe : MonoBehaviour
{
    public void f_SupprimerListe()
    {
        string directory = GeneralManager.directory;
        string titreListe = GetComponent<AssocierStructureListe>().listeAssociee.titre;

        File.Delete(directory + titreListe + ".txt");

        if (GameObject.Find("Commentaire(Clone)")) Destroy(GameObject.Find("Commentaire(Clone)"));

        Destroy(gameObject);
    }
}
