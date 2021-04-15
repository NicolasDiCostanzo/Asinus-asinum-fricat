using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AssocierStructureListe : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject commentairePrefab;
    GameObject commentairePanel_instance;
    [HideInInspector] public ListeDeMot listeAssociee;

    public void CreerPanelCommentaire()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;

        commentairePanel_instance = Instantiate(commentairePrefab);
        commentairePanel_instance.GetComponentInChildren<TextMeshProUGUI>().text = listeAssociee.commentaire;
        commentairePanel_instance.transform.SetParent(canvasTransform, false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (listeAssociee.commentaire != "") CreerPanelCommentaire();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(commentairePanel_instance);
    }

    public void PasserCetteListeAuGeneralManager()
    {
        GeneralManager._gmListe = listeAssociee;
    }
}
