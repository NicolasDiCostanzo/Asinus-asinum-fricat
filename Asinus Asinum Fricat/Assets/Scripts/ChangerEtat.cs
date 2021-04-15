using UnityEngine;
using static GeneralManager;

public class ChangerEtat : MonoBehaviour
{
    [SerializeField] Etat nouvelleEtat;

    public void f_ChangerEtat() { _etat = nouvelleEtat; }
}
