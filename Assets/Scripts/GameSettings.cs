using UnityEngine;
using System;
using System.Collections;

public class GameSettings : MonoBehaviour {

	void Awake()
    {
        DontDestroyOnLoad(this);
    }

        // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SaveCharacterData()
    {
        PlayerCharacter pcClass = GameObject.Find("Player Character").GetComponent<PlayerCharacter>();
        PlayerPrefs.SetString("PlayerName",pcClass.name);
        PlayerPrefs.DeleteAll();

        //if level modifier are different for each skill vital or attribute you must save them as well

        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            PlayerPrefs.SetInt(((AttributeName)i).ToString() + " Base Value", pcClass.GetPrimaryAttribute(i).BaseValue);
            PlayerPrefs.SetInt(((AttributeName)i).ToString() + " EXP to LEVEL", pcClass.GetPrimaryAttribute(i).ExpToLevel);

        }
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " Base Value ", pcClass.GetVital(i).BaseValue);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " EXP to LEVEL", pcClass.GetVital(i).ExpToLevel);
            PlayerPrefs.SetInt(((VitalName)i).ToString() + " Current Value ", pcClass.GetVital(i).CurrentValue);
            PlayerPrefs.SetString(((VitalName)i).ToString() + " Mods", pcClass.GetVital(i).GetModifyingAttributesStrings());
        }
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " Base Value ", pcClass.GetSkill(i).BaseValue);
            PlayerPrefs.SetInt(((SkillName)i).ToString() + " EXP to LEVEL", pcClass.GetSkill(i).ExpToLevel);
            PlayerPrefs.SetString(((SkillName)i).ToString() + " Mods",pcClass.GetSkill(i).GetModifyingAttributesStrings());
        }

    }
    public void LoadCharacterData()
    {

    }
}
