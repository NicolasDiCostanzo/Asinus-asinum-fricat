using UnityEngine;

public class InstantierPanelConfirmation : MonoBehaviour
{
    [SerializeField] GameObject panelConfirmation;
    GameObject panelConfirmation_instance;


    public void InstantierPanel()
    {
        GameObject parent = GameObject.Find("Zone affichage container");

        panelConfirmation_instance = Instantiate(panelConfirmation);
        panelConfirmation_instance.transform.SetParent(parent.transform, false);
        panelConfirmation_instance.GetComponent<SupprimerListe>().listeAssociee = GetComponent<AssocierStructureListe>().listeAssociee;
        panelConfirmation_instance.GetComponent<SupprimerListe>().listeGO = gameObject;
    }
}
