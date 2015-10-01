public class Attribute : BaseStat {
    public Attribute()
    {
        _name = string.Empty;
        ExpToLevel = 50;
        LevelModifer = 1.05f;
    }
    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value; }
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

