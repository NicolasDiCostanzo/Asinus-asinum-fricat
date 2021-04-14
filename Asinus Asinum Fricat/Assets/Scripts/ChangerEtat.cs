using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GeneralManager;

public class ChangerEtat : MonoBehaviour
{
    [SerializeField] Etat nouvelleEtat;
    
    public void f_ChangerEtat() { etat = nouvelleEtat; }
}
