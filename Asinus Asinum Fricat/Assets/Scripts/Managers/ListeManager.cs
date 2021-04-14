using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Text.Json;
using System.Text.Json.Serialization;
using static GeneralManager;

public class ListeManager : MonoBehaviour
{
    [SerializeField] GameObject motPrefab;
    [SerializeField] GameObject blocTypeDeMotPrefab;
    [SerializeField] GameObject inputFieldPrefab;
    [SerializeField] GameObject titreBlocPrefab;
    [SerializeField] GameObject boutonSuppression;
    public static Transform zoneMilieu;

    TMP_InputField titreTMP, themeTMP, commentaireTMP;

    void Start() { 
        zoneMilieu = GameObject.Find("Zone milieu").transform;

        titreTMP = GameObject.Find("Titre Input").GetComponent<TMP_InputField>();
        themeTMP = GameObject.Find("Theme Input").GetComponent<TMP_InputField>();
        commentaireTMP = GameObject.Find("Commentaire Input").GetComponent<TMP_InputField>();

        if (etat == Etat.Modification) ChargerListe(_gmListe);
    }

    /// <summary>
    /// Pour chargement liste existante
    /// </summary>
    /// <param name="a_mot"></param>
    public void AjoutChamp(Mot a_mot)
    {
        TypeDeMot typeDeMot = a_mot.type;

        bool version = a_mot.version;

        if      (typeDeMot == TypeDeMot.Nom)         a_mot = new Nom(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, version);
        else if (typeDeMot == TypeDeMot.Adjectif1)   a_mot = new Adjectif1(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, version);
        else if (typeDeMot == TypeDeMot.Adjectif2)   a_mot = new Adjectif2(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, a_mot.champs[4].Value, version);
        else if (typeDeMot == TypeDeMot.Verbe)       a_mot = new Verbe(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, a_mot.champs[4].Value, a_mot.champs[5].Value, version);
        else if (typeDeMot == TypeDeMot.Locution)    a_mot = new Locution(a_mot.champs[0].Value, a_mot.champs[1].Value, version);

        AjouterInputsField(a_mot, true);
    }

    public void AjouterInputsField(Mot mot, bool chargementListeExistante)
    {
        string typeDeMot = mot.type.ToString();
        Debug.Log(typeDeMot);
        GameObject bloc = GameObject.Find("Bloc " + typeDeMot);

        if (bloc == null) bloc = AjoutBloc(typeDeMot, mot);
        else              bloc = GameObject.Find("Bloc " + typeDeMot.ToString());

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

            if (chargementListeExistante) inputFieldInstance.GetComponent<TMP_InputField>().text = mot.champs[i].Value;
            else                          inputFieldInstance.GetComponentInChildren<TextMeshProUGUI>().text = "Entrer " + mot.champs[i].Key;
        }

        GameObject boutonSuppression_instance = Instantiate(boutonSuppression);
        boutonSuppression_instance.transform.SetParent(instanceMot.transform, false);


        zoneEntrees.GetComponent<AdapterTailleParent>().UpdateCanvas();
    }

    public void AjoutChamp(TypeDeMot typeDeMot)
    {
        Mot mot = null;

        switch (typeDeMot)
        {
            case TypeDeMot.Nom:
                mot = new Nom("", "", "", "", false);
                break;
            case TypeDeMot.Adjectif1:
                mot = new Adjectif1("", "", "", "", false);
                break;
            case TypeDeMot.Adjectif2:
                mot = new Adjectif2("", "", "", "", "", false);
                break;
            case TypeDeMot.Verbe:
                mot = new Verbe("", "", "", "", "", "", false);
                break;
            case TypeDeMot.Locution:
                mot = new Locution("", "", false);
                break;
        }

        AjouterInputsField(mot, false);
    }

    GameObject AjoutBloc(string typeDeMot, Mot a_mot)
    {
        GameObject instanceBlocTypeDeMot = Instantiate(blocTypeDeMotPrefab);
        instanceBlocTypeDeMot.transform.SetParent(zoneMilieu, false);
        instanceBlocTypeDeMot.name = "Bloc " + typeDeMot;

        Debug.Log(a_mot.version);

        instanceBlocTypeDeMot.GetComponentInChildren<Toggle>().isOn = a_mot.version;

        if (a_mot != null)
        {
            instanceBlocTypeDeMot.GetComponentInChildren<AjouterTypeDeMot>().type = a_mot.type;

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
        ListeDeMot liste = new ListeDeMot(titreTMP.text, themeTMP.text, commentaireTMP.text);

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

            for (int i = 0; i < mot.transform.childCount - 1; i++)
                champs.Add(mot.transform.GetChild(i).GetComponent<TMP_InputField>().text);

            Mot motEnregistre = null;

            switch (typeDeMot)
            {
                case TypeDeMot.Nom:
                    motEnregistre = new Nom(champs[0], champs[1], champs[2], champs[3], false);
                    break;
                case TypeDeMot.Adjectif1:
                    motEnregistre = new Adjectif1(champs[0], champs[1], champs[2], champs[3], false);
                    break;
                case TypeDeMot.Adjectif2:
                    motEnregistre = new Adjectif2(champs[0], champs[1], champs[2], champs[3], champs[4], false);
                    break;
                case TypeDeMot.Verbe:
                    motEnregistre = new Verbe(champs[0], champs[1], champs[2], champs[3], champs[4], champs[5], false);
                    break;
                case TypeDeMot.Locution:
                    motEnregistre = new Locution(champs[0], champs[1], false);
                    break;
            }

            if (motEnregistre != null)
            {
                motEnregistre.version = a_version;
                motEnregistre.type = typeDeMot;
                a_liste.mots.Add(motEnregistre);
            }
        }
    }


    void TestChargerListe()
    {
        ListeDeMot _liste = new ListeDeMot("titre", "theme", "commentaire");

        //_liste.mots.Add(new Locution("loc", "trad"));
        //_liste.mots.Add(new Locution("loc2", "trad2"));
        //_liste.mots.Add(new Nom("nom", "nom", "genr", "tradcut"));
        //_liste.mots.Add(new Nom("nom2", "nom2", "genr2", "tradcut2"));
        //_liste.mots.Add(new Verbe("v", "p2", "inf", "imp", "sup", "traduction"));
        //_liste.mots.Add(new Verbe("v2", "p22", "inf2", "imp2", "sup2", "traduction2"));
        //_liste.mots.Add(new Adjectif1("v2", "p22", "inf2", "imp2"));

        ChargerListe(_liste);
    }

    public void ChargerListe(ListeDeMot a_liste)
    {
        ListeDeMot liste = a_liste;

        titreTMP.text = liste.titre;
        themeTMP.text = liste.theme;
        commentaireTMP.text = liste.commentaire;

        foreach (Mot mot in liste.mots) AjoutChamp(mot);
    }
}
