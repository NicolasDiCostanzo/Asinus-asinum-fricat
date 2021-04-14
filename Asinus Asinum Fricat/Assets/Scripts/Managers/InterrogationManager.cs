using TMPro;
using UnityEngine;
using static GeneralManager;

public class InterrogationManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI motsAFaire_tmp, motsFaits_tmp;
    [SerializeField] GameObject inputFieldPrefab, affichageBonneReponse;
    GameObject canvas;
    ListeDeMot liste;

    int tailleListe = 0, motsFaits = 0, motsJustes = 0;

    GameObject container;

    void Start()
    {
        liste = _gmListe;
        tailleListe = liste.mots.Count;

        container = GameObject.Find("Container");
        canvas = GameObject.Find("Canvas");

        TirageAuSort();

        UI_update();
    }

    private void Update() { if (Input.GetKeyDown(KeyCode.Space)) TirageAuSort(); }

    int r = 0;

    public void TirageAuSort()
    {

        if (motsFaits < tailleListe)
        {
            do { r = Random.Range(0, tailleListe); }
            while (liste.mots[r].dejaInterroge);
        }
        else
        {
            Debug.Log("Fin de liste");
            return;
        }

        Interroger(liste.mots[r]);
    }

    void Interroger(Mot a_mot)
    {
        motsFaits++;
        ViderContainer();

        Mot mot = a_mot;

        for (int i = 0; i < mot.champs.Count; i++)
        {
            GameObject inputFieldInstance = Instantiate(inputFieldPrefab);

            inputFieldInstance.transform.SetParent(container.transform, false);
            inputFieldInstance.name = "Inputfield " + mot.type + mot.champs[i].ToString();

            TMP_InputField tmpInputField = inputFieldInstance.GetComponent<TMP_InputField>();

            if (mot.version)
            {
                if (mot.champs[i].Key != Champs.Traduction)
                {
                    tmpInputField.text = mot.champs[i].Value;
                    tmpInputField.interactable = false;
                }
                else
                {
                    tmpInputField.text = "Entrer " + mot.champs[i].Key.ToString();
                }
            }
            else if (!mot.version)
            {
                if (mot.champs[i].Key == Champs.Traduction)
                {
                    tmpInputField.text = mot.champs[i].Value;
                    tmpInputField.interactable = false;
                }
                else
                {
                    tmpInputField.text = "Entrer " + mot.champs[i].Key.ToString();
                }

            }
        }

        a_mot.dejaInterroge = true;
    }

    void ViderContainer()
    {
        foreach (Transform child in container.transform) Destroy(child.gameObject);
    }

    public void VerifierReponse()
    {
        int i = 0;

        foreach (Transform inputField in container.transform)
        {
            string reponse = inputField.GetComponent<TMP_InputField>().text;

            if (reponse != liste.mots[r].champs[i].Value)
            {
                MauvaiseReponse();
                return;
            }

            i++;
        }

        BonneReponse();
    }

    void BonneReponse()
    {
        Debug.Log("bonneReponse");
        motsJustes++;

        UI_update();
        TirageAuSort();
    }

    void MauvaiseReponse()
    {
        Debug.Log("mauvaise reponse");
        UI_update();
        AfficherBonneReponse();
        TirageAuSort();
    }

    void AfficherBonneReponse()
    {
        GameObject afficherBonneReponse_instance = Instantiate(affichageBonneReponse);
        afficherBonneReponse_instance.transform.SetParent(canvas.transform, false);

        Mot mot = liste.mots[r];

        for (int i = 0; i < mot.champs.Count; i++)
        {
            GameObject inputFieldInstance = Instantiate(inputFieldPrefab);

            inputFieldInstance.transform.SetParent(afficherBonneReponse_instance.transform.GetChild(0), false);
            inputFieldInstance.name = "Inputfield " + mot.type + mot.champs[i].ToString();

            TMP_InputField tmpInputField = inputFieldInstance.GetComponent<TMP_InputField>();

            tmpInputField.text = mot.champs[i].Value;
            tmpInputField.interactable = false;
        }
    }

    void UI_update()
    {
        motsAFaire_tmp.text = motsFaits + "/" + tailleListe;
        motsFaits_tmp.text = motsJustes + "/" + motsFaits;
    }

}