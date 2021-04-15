using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public static string _folderName = "/Listes/";
    public static string _directory;
    public static ListeDeMot _gmListe;

    [SerializeField] GameObject pausePanel;
    GameObject pausePanel_instance;

    public static GeneralManager _instance;
    public static Etat _etat = Etat.Null;

    void Awake()
    {
        _directory = Application.persistentDataPath + _folderName;

        if (_instance != null && _instance != this)
        {
            DestroyImmediate(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update() { if (Input.GetKeyDown(KeyCode.Escape)) AfficherPause(); }

    void AfficherPause()
    {
        if ((SceneManager.GetActiveScene().name != "Menu principal") && (pausePanel_instance == null))
            pausePanel_instance = Instantiate(pausePanel);
    }

    [Serializable]
    public enum TypeDeMot
    {
        Nom,
        Adjectif1,
        Adjectif2,
        Verbe,
        Locution,
        Default
    }

    [Serializable]
    public enum Champs
    {
        Nominatif,
        Genitif,
        Genre,
        Masculin,
        Feminin,
        Neutre,
        Present1,
        Present2,
        Infinitif,
        Parfait,
        Supin,
        Locution,
        Traduction,
        Imparfait
    }

    public enum Etat
    {
        Null,
        Creation,
        Modification
    }

    public void QuitterApplication()
    {
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
        }
    }
}
