using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChargerScene : MonoBehaviour
{
    public void f_ChargerScene(string a_nomScene)
    {
        SceneManager.LoadScene(a_nomScene);
    }
}
