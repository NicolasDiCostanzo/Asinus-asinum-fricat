using System;
using static GeneralManager;

public class Locution : Mot
{
    public Locution(string a_locution, string a_traduction, string a_commentaire, bool version)
        : base(a_traduction, a_commentaire, version)
    {
        champs.Insert(0, new Champ(Champs.Locution, a_locution));

        type = TypeDeMot.Locution;
    }
}
