using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static GeneralManager;

public class ListeManager : MonoBehaviour
{
    [SerializeField] GameObject motPrefab;
    [SerializeField] GameObject blocTypeDeMotPrefab;
    [SerializeField] GameObject inputFieldPrefab;
    [SerializeField] GameObject titreBlocPrefab;
    public static Transform zoneMilieu;

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
                mot = new Adjectif1("", "", "", "");
                break;
            case TypeDeMot.Adjectif2:
                mot = new Adjectif2("", "", "", "", "");
                break;
            case TypeDeMot.Verbe:
                mot = new Verbe("", "", "", "", "", "");
                break;
            case TypeDeMot.Locution:
                mot = new Locution("", "");
                break;
        }


        GameObject bloc = GameObject.Find("Bloc " + typeDeMot);

        if (bloc == null) bloc = AjoutBloc(typeDeMot, mot);
        else bloc = GameObject.Find("Bloc " + typeDeMot);

        GameObject zoneEntrees = GameObject.Find(bloc.name + "/Zone entrees");
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


            //Pour charger liste existante avec ses valeurs : 
            //inputFieldInstance.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = "salut c'est moi";
        }
        Debug.Log(zoneEntrees.transform.parent.name);
        Debug.Log(zoneEntrees.name);
        zoneEntrees.GetComponent<AdapterTailleParent>().UpdateCanvas();
    }

    GameObject AjoutBloc(TypeDeMot typeDeMot, Mot a_mot)
    {
        GameObject instanceBlocTypeDeMot = Instantiate(blocTypeDeMotPrefab);
        instanceBlocTypeDeMot.transform.SetParent(zoneMilieu, false);
        instanceBlocTypeDeMot.name = "Bloc " + typeDeMot;

        if (a_mot != null)
        {
            string colonneNom = typeDeMot.ToString();
            Transform parentMot = GameObject.Find(instanceBlocTypeDeMot.name + "/Zone entrees").transform;

            GameObject titreBlocInstance = Instantiate(titreBlocPrefab);
            titreBlocInstance.transform.SetParent(parentMot.transform, false);
            titreBlocInstance.name = colonneNom;
            titreBlocInstance.GetComponent<TextMeshProUGUI>().text = colonneNom;

        }

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
                    motEnregistre = new Adjectif1(champs[0], champs[1], champs[2], champs[3]);
                    break;
                case TypeDeMot.Adjectif2:
                    motEnregistre = new Adjectif2(champs[0], champs[1], champs[2], champs[3], champs[4]);
                    break;
                case TypeDeMot.Verbe:
                    motEnregistre = new Verbe(champs[0], champs[1], champs[2], champs[3], champs[4], champs[5]);
                    break;
                case TypeDeMot.Locution:
                    motEnregistre = new Locution(champs[0], champs[1]);
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
