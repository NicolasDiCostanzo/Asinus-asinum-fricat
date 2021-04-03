using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AdapterTailleParent : MonoBehaviour
{
    public void UpdateCanvas()
    {
        StartCoroutine(AdapterCanvas());

    }
    IEnumerator AdapterCanvas()
    {
        yield return new WaitForEndOfFrame();
        Vector2 tailleParent = transform.parent.transform.GetComponent<RectTransform>().sizeDelta;
        transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(tailleParent.x, GetComponent<RectTransform>().rect.height);
        ListeManager.zoneMilieu.GetComponent<VerticalLayoutGroup>().enabled = false;
        ListeManager.zoneMilieu.GetComponent<VerticalLayoutGroup>().enabled = true;
    }
}
