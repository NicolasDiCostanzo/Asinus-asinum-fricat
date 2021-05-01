using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortcutsForInputsFields : MonoBehaviour
{
    EventSystem system;
    List<Selectable> selectables = new List<Selectable>();
    Selectable commentaire;
    Selectable currentSelection;

    void Start()
    {
        system = EventSystem.current;

        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.GetComponent<TMP_InputField>())
            {
                selectables.Add(child.gameObject.GetComponent<Selectable>());
            }
        }

        if(transform.parent) commentaire = transform.parent.GetChild(1).GetComponentInChildren<Selectable>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            currentSelection = system.currentSelectedGameObject.GetComponent<Selectable>();

            if (commentaire == currentSelection)
            {
                AjouterLigne(currentSelection);
                return;
            }

            if (currentSelection)
            {
                if (CurrentSelectedIndex() >= 0 && CurrentSelectedIndex() < selectables.Count - 1)
                {
                    currentSelection = selectables[CurrentSelectedIndex() + 1];
                    currentSelection.Select();

                }
                else if (CurrentSelectedIndex() == selectables.Count - 1)
                {
                    commentaire.Select();
                }
            }
        }
    }

    int CurrentSelectedIndex()
    {
        for (int i = 0; i < selectables.Count; i++)
        {
            if (selectables[i] == currentSelection) return i;
        }

        return -1;
    }

    void AjouterLigne(Selectable selection)
    {
        selection.transform.parent.parent.parent.parent.GetComponentInChildren<AjouterTypeDeMot>().AjouterChamps();
    }

    void SupprimerLigne(Selectable objetSelectionne)
    {
        if (objetSelectionne.transform.parent.parent.name == "Zone entrees")
            objetSelectionne.transform.parent.GetComponentInChildren<SuppressionParent>().SupprimerParent();
    }
}