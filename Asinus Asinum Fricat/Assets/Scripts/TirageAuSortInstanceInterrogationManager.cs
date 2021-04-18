using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirageAuSortInstanceInterrogationManager : MonoBehaviour
{
    InterrogationManager interrogationManager_instance;
    // Start is called before the first frame update
    void Start()
    {
        interrogationManager_instance = GameObject.Find("Interrogation Manager").GetComponent<InterrogationManager>();
    }

    public void TirageAuSort_Instance()
    {
        if (interrogationManager_instance.motsFaits < interrogationManager_instance.tailleListe)
            interrogationManager_instance.TirageAuSort();
        else
            interrogationManager_instance.AfficherPanelFinDeListe();

    }
}
