using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Factory_ZoneEntree : MonoBehaviour
{
    Mot typeMot;

    GameObject zoneEntrees;
    [SerializeField] GameObject colonneTitre;
    [SerializeField] GameObject inputField;

    void Start()
    {
        zoneEntrees = GameObject.Find("Zone entrees");

        typeMot = new Nom("","","","");

        Debug.Log((from champ in typeMot.champs select champ.Key).Distinct().ToList());

        IList list = typeMot.champs;

        zoneEntrees.GetComponent<GridLayoutGroup>().constraintCount = list.Count;

        for (int i = 0; i < list.Count; i++)
        {
            GameObject colonneTitreInstance = Instantiate(colonneTitre);
            colonneTitreInstance.transform.SetParent(zoneEntrees.transform);
            colonneTitre.GetComponent<TextMeshProUGUI>().text = list[i].ToString();
        }
    }

    void Update()
    {
        
    }
}
