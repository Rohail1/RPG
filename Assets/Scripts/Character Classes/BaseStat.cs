public class BaseStat  {

    private int _baseValue; //base value of this stat. aka current value of level
    private int _buffValue; //amout of the buff to this stat
    private int _expToLevel; // exp to get the next time
    private float _levelModifier; //modifier applied to the exp to raise the needed skill

    public BaseStat()
    {
        _baseValue = 0;
        _buffValue = 0;
        _expToLevel = 100;
        _levelModifier = 1.1f;
    }

    #region basic Getters and Setters

    public int BaseValue
    {
        get { return _baseValue; }
        set { _baseValue = value; }
    }

    public int BuffValue
    {
        get { return _buffValue; }
        set { _buffValue = value; }
    }
    
    public int ExpToLevel
    {
        get { return _expToLevel; }
        set { _expToLevel = value; }
    }
    
    public float LevelModifer
    {
        get { return _levelModifier; }
        set { _levelModifier = value; }
    }


    #endregion

    private int CalculateExpToLevel()
    {
        return  (int)(_expToLevel * _levelModifier);
    }
    public void LevelUp()
    {
        _expToLevel = CalculateExpToLevel();
        _baseValue++;
    }
    public int AdjustedBaseValue
    {
        get { return _baseValue + _buffValue; }
    }

}
