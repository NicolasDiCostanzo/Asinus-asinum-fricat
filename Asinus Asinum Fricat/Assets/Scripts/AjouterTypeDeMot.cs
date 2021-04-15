using UnityEngine;
using static GeneralManager;

public class AjouterTypeDeMot : MonoBehaviour
{
    ListeManager listeManager;
    [HideInInspector] public TypeDeMot type;

    private void Awake()
    {
        listeManager = GameObject.Find("Manager").GetComponent<ListeManager>();
    }

    public void AjouterChamps()
    {
        listeManager.AjoutChamp(type);
    }
}
