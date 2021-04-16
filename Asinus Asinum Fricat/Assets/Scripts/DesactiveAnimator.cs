using UnityEngine;

public class DesactiveAnimator : MonoBehaviour
{
    public void f_DesactiveAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }
}
