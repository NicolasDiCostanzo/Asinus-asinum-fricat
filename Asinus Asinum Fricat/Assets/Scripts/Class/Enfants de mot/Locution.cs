using System;
using static GeneralManager;

public class Locution : Mot
{
    public Locution(string a_locution, string a_traduction, bool version)
        : base(a_traduction, version)
    {
        champs.Insert(0, new Champ(Champs.Locution, a_locution));

        type = TypeDeMot.Locution;
    }
}
