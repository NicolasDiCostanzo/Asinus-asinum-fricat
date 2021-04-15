using System;
using static GeneralManager;

[Serializable]
public class Nom : Mot
{
    public Nom(string a_nominatif, string a_genitif, string a_genre, string a_traduction, bool version)
        : base(a_traduction, version)
    {
        champs.Insert(0, new Champ(Champs.Nominatif, a_nominatif));
        champs.Insert(1, new Champ(Champs.Genitif, a_genitif));
        champs.Insert(2, new Champ(Champs.Genre, a_genre));

        type = TypeDeMot.Nom;
    }
}
