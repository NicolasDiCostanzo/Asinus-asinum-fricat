using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    [Serializable]
    public enum TypeDeMot
    {
        Nom,
        Adjectif1,
        Adjectif2,
        Verbe,
        Locution
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
}
