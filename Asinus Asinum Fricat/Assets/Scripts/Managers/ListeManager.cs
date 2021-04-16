using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GeneralManager;

public class ListeManager : MonoBehaviour
{
    [SerializeField] GameObject motPrefab, blocTypeDeMotPrefab, inputFieldPrefab, titreBlocPrefab, boutonSuppression, informationReussiteSauvegarde;
    [SerializeField] float frequenceSauvegarde;
    float tempsAvantProchaineSauvegarde;

    Transform canvas;
    [HideInInspector] public static Transform zoneMilieu;

    TMP_InputField titreTMP, themeTMP, commentaireTMP;

    bool versionParDefaut = true, sauvegardeAutomatique;

    Toggle toggle;

    Animator iconeSauvegardeAnimator;

    void Start()
    {
        canvas = GameObject.Find("Canvas").transform;

        zoneMilieu = GameObject.Find("Zone milieu").transform;

        titreTMP = GameObject.Find("Titre Input").GetComponent<TMP_InputField>();
        themeTMP = GameObject.Find("Theme Input").GetComponent<TMP_InputField>();
        commentaireTMP = GameObject.Find("Commentaire Input").GetComponent<TMP_InputField>();

        if (_etat == Etat.Modification) ChargerListe(_gmListe);

        tempsAvantProchaineSauvegarde = frequenceSauvegarde;

        toggle = GameObject.Find("Toggle").GetComponent<Toggle>();

        iconeSauvegardeAnimator = GameObject.Find("Icon sauvegarde").GetComponent<Animator>();
    }

    void Update()
    {
        if (sauvegardeAutomatique) SauvegardeAutomatique();
    }

    public void ChangerValeurSauvgardeAutomatique() {
        bool toggleValue = toggle.isOn;

        sauvegardeAutomatique = toggleValue;
        titreTMP.interactable = !toggleValue;
    }

    void SauvegardeAutomatique()
    {
        tempsAvantProchaineSauvegarde -= Time.deltaTime;

        if (tempsAvantProchaineSauvegarde <= 0)
        {
            SauvegarderListe(true);
            tempsAvantProchaineSauvegarde = frequenceSauvegarde;
            iconeSauvegardeAnimator.enabled = true;
        }
    }

    public void AjoutChamp(Mot a_mot)
    {
        TypeDeMot typeDeMot = a_mot.type;

        bool version = a_mot.version;

        if      (typeDeMot == TypeDeMot.Nom)        a_mot = new Nom(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, version);
        else if (typeDeMot == TypeDeMot.Adjectif1)  a_mot = new Adjectif1(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, version);
        else if (typeDeMot == TypeDeMot.Adjectif2)  a_mot = new Adjectif2(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, a_mot.champs[4].Value, version);
        else if (typeDeMot == TypeDeMot.Verbe)      a_mot = new Verbe(a_mot.champs[0].Value, a_mot.champs[1].Value, a_mot.champs[2].Value, a_mot.champs[3].Value, a_mot.champs[4].Value, a_mot.champs[5].Value, version);
        else if (typeDeMot == TypeDeMot.Locution)   a_mot = new Locution(a_mot.champs[0].Value, a_mot.champs[1].Value, version);

        AjouterInputsField(a_mot, true);
    }

    public void AjouterInputsField(Mot mot, bool chargementListeExistante)
    {
        string typeDeMot = mot.type.ToString();
        GameObject bloc = GameObject.Find("Bloc " + typeDeMot);

        if (bloc == null) bloc = AjoutBloc(typeDeMot, mot);
        else bloc = GameObject.Find("Bloc " + typeDeMot.ToString());

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
            else inputFieldInstance.GetComponentInChildren<TextMeshProUGUI>().text = "Entrer " + mot.champs[i].Key;

            if (i == 0) EventSystem.current.SetSelectedGameObject(inputFieldInstance.gameObject, null); //Focus sur le premier champ d'inputfiel créé
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
                mot = new Nom("", "", "", "", versionParDefaut);
                break;
            case TypeDeMot.Adjectif1:
                mot = new Adjectif1("", "", "", "", versionParDefaut);
                break;
            case TypeDeMot.Adjectif2:
                mot = new Adjectif2("", "", "", "", "", versionParDefaut);
                break;
            case TypeDeMot.Verbe:
                mot = new Verbe("", "", "", "", "", "", versionParDefaut);
                break;
            case TypeDeMot.Locution:
                mot = new Locution("", "", versionParDefaut);
                break;
        }

        AjouterInputsField(mot, false);
    }

    GameObject AjoutBloc(string typeDeMot, Mot a_mot)
    {
        GameObject instanceBlocTypeDeMot = Instantiate(blocTypeDeMotPrefab);
        instanceBlocTypeDeMot.transform.SetParent(zoneMilieu, false);
        instanceBlocTypeDeMot.name = "Bloc " + typeDeMot;

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

    public void SauvegarderListe(bool sauvegardeAutomatique)
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

        bool succesSauvegarde = liste.JsonSauvegarde();

        if (succesSauvegarde && !sauvegardeAutomatique)
        {
            GameObject informationReussiteSauvegarde_instance = Instantiate(informationReussiteSauvegarde);
            informationReussiteSauvegarde_instance.transform.SetParent(canvas, false);
            informationReussiteSauvegarde_instance.GetComponentInChildren<TextMeshProUGUI>().text = "Sauvegarde réussie !";

            Debug.Log("Sauvegarde réussie");
        }
        else if (!succesSauvegarde)
        {
            GameObject informationReussiteSauvegarde_instance = Instantiate(informationReussiteSauvegarde);
            informationReussiteSauvegarde_instance.transform.SetParent(canvas, false);
            informationReussiteSauvegarde_instance.GetComponentInChildren<TextMeshProUGUI>().text = "La sauvegarde a échoué...";

            Debug.Log("Sauvegarde echouee");
        }
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
                    motEnregistre = new Nom(champs[0], champs[1], champs[2], champs[3], a_version);
                    break;
                case TypeDeMot.Adjectif1:
                    motEnregistre = new Adjectif1(champs[0], champs[1], champs[2], champs[3], a_version);
                    break;
                case TypeDeMot.Adjectif2:
                    motEnregistre = new Adjectif2(champs[0], champs[1], champs[2], champs[3], champs[4], a_version);
                    break;
                case TypeDeMot.Verbe:
                    motEnregistre = new Verbe(champs[0], champs[1], champs[2], champs[3], champs[4], champs[5], a_version);
                    break;
                case TypeDeMot.Locution:
                    motEnregistre = new Locution(champs[0], champs[1], a_version);
                    break;
            }

            if (motEnregistre != null)
            {
                //motEnregistre.version = a_version;
                motEnregistre.type = typeDeMot;
                a_liste.mots.Add(motEnregistre);
            }
        }
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
