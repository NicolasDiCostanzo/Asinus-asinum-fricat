using System;
using static GeneralManager;

public class Verbe : Mot
{
    public Verbe(string a_present1, string a_present2, string a_infinitif, string a_imparfait, string a_supin, string a_traduction, string a_commentaire, bool version)
    : base(a_traduction, a_commentaire, version)
    {
        champs.Insert(0, new Champ(Champs.Present1, a_present1));
        champs.Insert(1, new Champ(Champs.Present2, a_present2));
        champs.Insert(2, new Champ(Champs.Infinitif, a_infinitif));
        champs.Insert(3, new Champ(Champs.Imparfait, a_imparfait));
        champs.Insert(4, new Champ(Champs.Supin, a_supin));

        type = TypeDeMot.Verbe;
    }
}
