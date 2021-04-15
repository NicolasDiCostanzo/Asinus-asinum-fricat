using static GeneralManager;

public class Adjectif1 : Mot
{
    public Adjectif1(string a_masculin, string a_feminin, string a_neutre, string a_traduction, bool version)
        : base(a_traduction, version)
    {
        champs.Insert(0, new Champ(Champs.Masculin, a_masculin));
        champs.Insert(1, new Champ(Champs.Feminin, a_feminin));
        champs.Insert(2, new Champ(Champs.Neutre, a_neutre));

        type = TypeDeMot.Adjectif1;
    }
}
