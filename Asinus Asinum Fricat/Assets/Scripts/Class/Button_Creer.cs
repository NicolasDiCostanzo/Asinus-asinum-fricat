using UnityEngine;

public class Button_Creer : MonoBehaviour
{
    ListeManager manager;
    [SerializeField] GeneralManager.TypeDeMot typeMotAssocie;

    private void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<ListeManager>();
    }

    public void CreerChamp() { manager.AjoutChamp(typeMotAssocie); }
}
