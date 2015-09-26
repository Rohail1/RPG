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
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void SetupPrimaryAttributes()
    {
        for (int i = 0; i < _primaryAttribute.Length; i++)
        {
            _primaryAttribute[i] = new Attribute();
        }
    }
    private void SetupVitals()
    {
        for (int i = 0; i < _vital.Length; i++)
        {
            _vital[i] = new Vital();
        }
    }
    private void SetupSkills()
    {
        for (int i = 0; i < _skill.Length; i++)
        {
            _skill[i] = new Skill();
        }
    }
    public void AddExp(uint exp)
    {
        _freeExp += exp;
        CalculateLevel();
    }
    public void CalculateLevel ()
    {

    }
}
