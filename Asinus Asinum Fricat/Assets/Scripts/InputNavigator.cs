using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputNavigator : MonoBehaviour
{
    EventSystem system;

    void Start() { system = EventSystem.current; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnRight();

            if (next != null)
                if (next.GetComponentInChildren<TMP_InputField>()) system.SetSelectedGameObject(next.gameObject, new BaseEventData(system));
        }
    }
}