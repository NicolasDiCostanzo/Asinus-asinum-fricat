using UnityEngine;

public class SuppressionParent : MonoBehaviour
{
    public void SupprimerParent()
    {
        int nbrEntrees = transform.parent.parent.parent.childCount - 1;

        Debug.Log(nbrEntrees);

        if (nbrEntrees - 1 == 0) Destroy(transform.parent.parent.parent.parent.gameObject);
        else Destroy(transform.parent.parent.gameObject);

        GetComponentInParent<AdapterTailleParent>().UpdateCanvas();
    }
}
