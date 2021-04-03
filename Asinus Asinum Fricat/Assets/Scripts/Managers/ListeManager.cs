using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GeneralManager;

public class ListeManager : MonoBehaviour
{
    [SerializeField] GameObject motPrefab;
    [SerializeField] GameObject blocTypeDeMot;
    [SerializeField] GameObject inputFieldPrefab;
    Transform zoneMilieu;
    [SerializeField] GameObject colonneTitre;

    void Start()
    {
        zoneMilieu = GameObject.Find("Zone milieu").transform;
    }

    public void AjoutChamp(TypeDeMot typeDeMot)
    {
        Mot mot = null;

        switch (typeDeMot)
        {
            case TypeDeMot.Nom:
                mot = new Nom("", "", "", "");
                break;
            case TypeDeMot.Adjectif1:
                break;
            case TypeDeMot.Adjectif2:
                break;
            case TypeDeMot.Verbe:
                mot = new Verbe("", "", "", "", "", "");
                break;
            case TypeDeMot.Locution:
                break;
        }


        GameObject parentMots = GameObject.Find("Bloc " + typeDeMot);

        if (parentMots == null) parentMots = AjoutBloc(typeDeMot, mot);
        else parentMots = GameObject.Find("Bloc " + typeDeMot);

        GameObject zoneEntrees = GameObject.Find(parentMots.name + "/Bloc Champ/Zone entrees");
        GameObject instanceMot = Instantiate(motPrefab);
        instanceMot.name = typeDeMot.ToString();
        instanceMot.tag = typeDeMot.ToString();
        instanceMot.transform.SetParent(zoneEntrees.transform, false);

        for (int i = 0; i < mot.champs.Count; i++)
        {
            GameObject inputFieldInstance = Instantiate(inputFieldPrefab);
            inputFieldInstance.transform.SetParent(instanceMot.transform, false);
            inputFieldInstance.name = "Inputfield " + typeDeMot + mot.champs[i].ToString();
            inputFieldInstance.GetComponentInChildren<TextMeshProUGUI>().text = "Entrer " + mot.champs[i].ToString();
        }
    }

    GameObject AjoutBloc(TypeDeMot typeDeMot, Mot a_mot)
    {
        GameObject instanceBlocTypeDeMot = Instantiate(blocTypeDeMot);
        instanceBlocTypeDeMot.transform.SetParent(zoneMilieu, false);
        instanceBlocTypeDeMot.name = "Bloc " + typeDeMot;

        //if (a_mot != null)
        //{
        //    int nbChamps = a_mot.champs.Count;

        //    Transform parentMot = GameObject.Find(instanceBlocTypeDeMot.name + "/Bloc Champ/Zone entrees").transform;
        //    parentMot.GetComponent<GridLayoutGroup>().constraintCount = nbChamps;

        //    for (int i = 0; i < nbChamps; i++)
        //    {
        //        Debug.Log(a_mot.champs[i].ToString());

        //        string colonneNom = a_mot.champs[i].ToString();
        //        Debug.Log(colonneNom);

        //        GameObject colonneTitreInstance = Instantiate(colonneTitre);
        //        colonneTitreInstance.transform.SetParent(parentMot.transform, false);
        //        colonneTitreInstance.name = colonneNom;
        //        colonneTitre.GetComponent<TextMeshProUGUI>().text = colonneNom;
        //    }
        //}

        return GameObject.Find("Bloc " + typeDeMot);
    }


    public void SauvegarderListe()
    {
        string inputFieldHierarchie = "Input/Text Area/Text";

        string titre = GameObject.Find("Titre " + inputFieldHierarchie).GetComponent<TextMeshProUGUI>().text;
        string theme = GameObject.Find("Theme " + inputFieldHierarchie).GetComponent<TextMeshProUGUI>().text;
        string commentaire = GameObject.Find("Commentaire " + inputFieldHierarchie).GetComponent<TextMeshProUGUI>().text;

        ListeDeMot liste = new ListeDeMot(titre, theme, commentaire);

        liste.mots.Clear();

        foreach (int i in Enum.GetValues(typeof(TypeDeMot)))
        {
            TypeDeMot typeDeMot = (TypeDeMot)i;

            if (GameObject.Find("Bloc " + typeDeMot))
            {
                Toggle toggleBoxVersion = GameObject.Find("Bloc " + typeDeMot).GetComponentInChildren<Toggle>();
                EnregistrerMots(typeDeMot, liste, toggleBoxVersion.isOn);
            }
        }

        liste.JsonSauvegarde();
    }

    void EnregistrerMots(TypeDeMot typeDeMot, ListeDeMot a_liste, bool a_version)
    {
        GameObject[] mots = GameObject.FindGameObjectsWithTag(typeDeMot.ToString());

        foreach (GameObject mot in mots)
        {
            List<string> champs = new List<string>();

            for (int i = 0; i < mot.transform.childCount; i++)
                champs.Add(mot.transform.GetChild(i).GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text);

            Mot motEnregistre = null;

            switch (typeDeMot)
            {
                case TypeDeMot.Nom:
                    motEnregistre = new Nom(champs[0], champs[1], champs[2], champs[3]);
                    break;
                case TypeDeMot.Adjectif1:
                    break;
                case TypeDeMot.Adjectif2:
                    break;
                case TypeDeMot.Verbe:
                    motEnregistre = new Verbe(champs[0], champs[1], champs[2], champs[3], champs[4], champs[5]);
                    break;
                case TypeDeMot.Locution:
                    break;
            }

            if (motEnregistre != null)
            {
                motEnregistre.version = a_version;
                a_liste.mots.Add(motEnregistre);
            }

        }
    }
}
