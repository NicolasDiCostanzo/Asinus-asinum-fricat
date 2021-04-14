using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuppressionParent : MonoBehaviour
{
    public void SupprimerParent()
    {
        int nbrEntrees = transform.parent.parent.childCount - 1;

        if (nbrEntrees - 1 == 0) Destroy(transform.parent.parent.parent.gameObject);
        else Destroy(transform.parent.gameObject);
    }
}
