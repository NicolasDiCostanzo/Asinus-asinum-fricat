using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShortcutsForInputsFields : MonoBehaviour
{
    EventSystem system;

    void Start() { system = EventSystem.current; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Delete))
        {
            Selectable selectable = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();

            if (selectable.gameObject != null)
            {
                if (Input.GetKeyDown(KeyCode.Tab)) AjouterLigne(selectable);
                else SupprimerLigne(selectable);
            }
        }
    }

    void AjouterLigne(Selectable next)
    {
        if (next.GetComponentInChildren<TMP_InputField>())
            system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
        else
            if (next.transform.parent.parent.name == "Zone entrees") next.transform.parent.parent.parent.GetComponentInChildren<AjouterTypeDeMot>().AjouterChamps();
    }

    void SupprimerLigne(Selectable objetSelectionne)
    {

        if (objetSelectionne.transform.parent.parent.name == "Zone entrees")
            objetSelectionne.transform.parent.GetComponentInChildren<SuppressionParent>().SupprimerParent();
    }
}