using UnityEngine;
using System.Collections;
using System;

public class BaseCharacter : MonoBehaviour {

    private String _name;

    public String Name
    {
        get { return _name; }
        set { _name = value; }
    }
    private int _level;

    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }
    private uint _freeExp;

    public uint FreeExp
    {
        get { return _freeExp; }
        set { _freeExp = value; }
    }

    private Attribute[] _primaryAttribute;
    private Vital[] _vital;
    private Skill[] _skill;

    public void Awake()
    {
        _name = string.Empty;
        _level = 0;
        _freeExp = 0;
        _primaryAttribute = new Attribute[Enum.GetValues(typeof(AttributeName)).Length];
        _vital = new Vital[Enum.GetValues(typeof(VitalName)).Length];
        _skill = new Skill[Enum.GetValues(typeof(SkillName)).Length];
        SetupPrimaryAttributes();
        SetupSkills();
        SetupVitals();
    }
    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < _primaryAttribute.Length; i++)
        {
            _primaryAttribute[i] = new Attribute();
            _primaryAttribute[i].Name = ((AttributeName)i).ToString();
        }
    }
    private void SetupVitals()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i] = new Vital();
        }
        SetupVitalModifier();
    }
    private void SetupSkills()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i] = new Skill();
        }
        SetupSkillModifier();
    }
    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }
    public void CalculateLevel ()
    {

    }

    public Attribute GetPrimaryAttribute(int index)
    {
        return _primaryAttribute[index];
    }
    public Vital GetVital(int index)
    {
        return _vital[index];
    }
    public Skill GetSkill(int index)
    {
        return _skill[index];
    }
    private void SetupVitalModifier()
    {
        //heath
        ModifyingAttribute health = new ModifyingAttribute();
        health.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
        health.ratio = .5f;
        GetVital((int)VitalName.Health).AddModifer(health);
        //energy
        ModifyingAttribute energyModifier = new ModifyingAttribute();
        energyModifier.attribute = GetPrimaryAttribute((int)AttributeName.Constitution);
        energyModifier.ratio = 1f;
        GetVital((int)VitalName.Energy).AddModifer(energyModifier);
        //Mana
        ModifyingAttribute manaModifier = new ModifyingAttribute();
        manaModifier.attribute = GetPrimaryAttribute((int)AttributeName.Willpower);
        manaModifier.ratio = 1f;
        GetVital((int)VitalName.Mana).AddModifer(manaModifier);
    }
    private void SetupSkillModifier()
    {
        // Old way Melee Offence
        ModifyingAttribute melee_Offence_1 = new ModifyingAttribute();
        ModifyingAttribute melee_Offence_2 = new ModifyingAttribute();
        melee_Offence_1.attribute = GetPrimaryAttribute((int)AttributeName.Strength);
        melee_Offence_1.ratio = .33f;
        melee_Offence_2.attribute = GetPrimaryAttribute((int)AttributeName.Nimbleness);
        melee_Offence_2.ratio = .33f;
        GetSkill((int)SkillName.Melee_Offence).AddModifer(melee_Offence_1);
        GetSkill((int)SkillName.Melee_Offence).AddModifer(melee_Offence_2);
        // new way Melee Defence
        GetSkill((int)SkillName.Melee_Deffence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Melee_Deffence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Constitution), .33f));
        // Magic Defence
        GetSkill((int)SkillName.Magic_Defence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Magic_Defence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
        // Magic Offence
        GetSkill((int)SkillName.Magic_Offence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Magic_Offence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Willpower), .33f));
        //Range Offence
        GetSkill((int)SkillName.Ranged_Offence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Concentration), .33f));
        GetSkill((int)SkillName.Ranged_Offence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        //Range Defence
        GetSkill((int)SkillName.Ranged_Deffence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Speed), .33f));
        GetSkill((int)SkillName.Ranged_Deffence).AddModifer(new ModifyingAttribute(GetPrimaryAttribute((int)AttributeName.Nimbleness), .33f));
    }

    public void UpdateStats()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i].Update();
        }
        for (int j = 0; j < _skill.Length; j++)
        {
            _skill[j].Update();
        }
    }
}
