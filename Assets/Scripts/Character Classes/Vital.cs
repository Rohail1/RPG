public class Vital : ModifiedStat {
    private int _curValue;

    public int CurrentValue
    {
        get {

            if (_curValue > AdjustedBaseValue)
            {
                _curValue = AdjustedBaseValue;
            }
            return _curValue;
        }
        set { _curValue = value; }
    }

    public Vital()
    {
        _curValue = 0;
        ExpToLevel = 50;
        LevelModifer = 1.1f;
    }

}

public enum VitalName
{
    Health,
    Energy,
    Mana
}