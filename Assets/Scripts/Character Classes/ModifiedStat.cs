using System.Collections.Generic;
public class ModifiedStat : BaseStat {

    private List<ModifyingAttribute> mods;
    private int _modValue;

    public ModifiedStat()
    {
        mods = new List<ModifyingAttribute>();
        _modValue = 0;
    }
    public void AddModifer(ModifyingAttribute mod)
    {
        mods.Add(mod);
    }
    private void CalculateModValue()
    {
        _modValue = 0;
        if (mods.Count > 0)
        {
            foreach (ModifyingAttribute att in mods)
            {
                _modValue += (int)(att.attribute.AdjustedBaseValue * att.ratio);
            }
        }
    }
    public new int AdjustedBaseValue
    {
        get { return BaseValue + BuffValue + _modValue; }
    }
    public void Update()
    {
        CalculateModValue();
    }
}
public struct ModifyingAttribute
{
    public Attribute attribute;
    public float ratio;
}
