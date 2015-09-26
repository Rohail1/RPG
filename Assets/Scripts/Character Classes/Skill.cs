public class Skill : ModifiedStat {
    private bool _known;
    public Skill()
    {
        _known = false;
        ExpToLevel = 25;
        LevelModifer = 1.1f;
    }
    public bool Known
    {
        get { return _known; }
        set { _known = value; }
    }
}

public enum SkillName
{
    Melee_Offence,
    Melee_Deffence,
    Ranged_Offence,
    Ranged_Deffence,
    Magic_Offence,
    Magic_Defence
}
