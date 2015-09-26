public class Attribute : BaseStat {
    public Attribute()
    {
        ExpToLevel = 50;
        LevelModifer = 1.05f;
    }
}

public enum AttributeName
{
    Strength,
    Constitution,
    Nimbleness,
    Speed,
    Concentration,
    Willpower,
    Charisma
}

