using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class AfficherCommentaire : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject commentairePrefab;
    GameObject commentairePanel_instance;
    [HideInInspector] public string commentaire;
    
    public void CreerPanelCommentaire()
    {
        Transform canvasTransform = GameObject.Find("Canvas").transform;

        commentairePanel_instance = Instantiate(commentairePrefab);
        commentairePanel_instance.GetComponentInChildren<TextMeshProUGUI>().text = commentaire;
        commentairePanel_instance.transform.SetParent(canvasTransform, false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        CreerPanelCommentaire();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(commentairePanel_instance);
    }
}
