using UnityEngine;
using System.Collections;
using System;

public class PlayerGenerator : MonoBehaviour {

    private PlayerCharacter _toon;
    private const int STARTING_VALUE = 350;
    private const int MIN_ATTRIBUTE_VALUE = 10;
    private const int STARTING_POINTS = 50;
    private int pointsLeft;
    public GameObject PlayerPrefab;

    private const int OFFSET = 5;
    private const int LINE_HEIGHT = 20;
    private const int STAT_LABEL_WIDTH = 100;
    private const int BASEVALUE_LABEL = 30;
    private const int BUTTON_WITDH = 20;
    private const int BUTTON_HEIGHT = 20;
    private const int STARTING_POS = 40;

    // Use this for initialization

    void Start () {
        GameObject pc = Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity) as GameObject ;
        pc.name = "Player Character";

        //_toon = new PlayerCharacter();
        //_toon.Awake();
        _toon = pc.GetComponent<PlayerCharacter>();
        pointsLeft = STARTING_VALUE;
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            _toon.GetPrimaryAttribute(i).BaseValue = STARTING_POINTS;
            pointsLeft -= (STARTING_POINTS - MIN_ATTRIBUTE_VALUE);
        }
        _toon.UpdateStats();


    }
	
	// Update is called once per frame
	void Update () {
      
	}

    void OnGUI()
    {
        DisplayName();
        DisplayPointsLeft();
        DisplayAttributes();
        DisplayVitals();
        DisplaySkills();
        if (_toon.Name == String.Empty || pointsLeft > 0)
        {
            DisplayCreateLabel();
        }
        else
        {
            DiplayCreateButton();
        }


    }

    private void DisplayName()
    {
        GUI.Label(new Rect(OFFSET, 10, 50, 25), "Name: ");
        _toon.Name = GUI.TextField(new Rect(65, 10, 100, 25), _toon.Name);

    }
    private void DisplayAttributes()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            GUI.Label(new Rect(OFFSET, 40 + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((AttributeName)i).ToString());
            GUI.Label(new Rect(STAT_LABEL_WIDTH+OFFSET, STARTING_POS + (i * LINE_HEIGHT), BASEVALUE_LABEL, LINE_HEIGHT), _toon.GetPrimaryAttribute(i).AdjustedBaseValue.ToString());
            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL, STARTING_POS + (i * LINE_HEIGHT), BUTTON_WITDH, BUTTON_HEIGHT), "-"))
            {
                if (pointsLeft > 0 && _toon.GetPrimaryAttribute(i).BaseValue > MIN_ATTRIBUTE_VALUE)
                {
                    _toon.GetPrimaryAttribute(i).BaseValue--;
                    pointsLeft++;
                    _toon.UpdateStats();
                }
            }
            if (GUI.Button(new Rect(OFFSET + STAT_LABEL_WIDTH + BASEVALUE_LABEL + BUTTON_WITDH, STARTING_POS + (i * LINE_HEIGHT), BUTTON_WITDH, BUTTON_HEIGHT), "+"))
            {
                if (pointsLeft > 0)
                {
                    _toon.GetPrimaryAttribute(i).BaseValue++;
                    pointsLeft--;
                    _toon.UpdateStats();
                }
            }
        
        }
    }
    private void DisplayVitals()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        { 
            GUI.Label(new Rect(OFFSET, STARTING_POS + ((i+7) * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((VitalName)i).ToString());
            GUI.Label(new Rect(OFFSET + STAT_LABEL_WIDTH, STARTING_POS + ((i+7) * LINE_HEIGHT), BASEVALUE_LABEL, LINE_HEIGHT), _toon.GetVital(i).AdjustedBaseValue.ToString());
        }
    }
    private void DisplaySkills()
    {
        for (int i = 0; i < Enum.GetValues(typeof(SkillName)).Length; i++)
        {
            GUI.Label(new Rect(OFFSET*3 + STAT_LABEL_WIDTH + BASEVALUE_LABEL + BUTTON_WITDH*2, STARTING_POS + (i * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), ((SkillName)i).ToString());
            GUI.Label(new Rect(OFFSET*3 + STAT_LABEL_WIDTH*2 + BASEVALUE_LABEL + BUTTON_WITDH*2, STARTING_POS + (i * LINE_HEIGHT), BASEVALUE_LABEL, LINE_HEIGHT), _toon.GetSkill(i).AdjustedBaseValue.ToString());
        }
    }
    private void DisplayPointsLeft()
    {
        GUI.Label(new Rect(250, 10, 100, 25), "Points Left: " + pointsLeft);

    }
    private void DiplayCreateButton()
    {
      if(GUI.Button(new Rect(Screen.width/2 -50, STARTING_POS + ( 10 * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), "Create"))
        {
            GameObject gs = GameObject.Find("GameSettings");
            GameSettings gsScript = gs.GetComponent<GameSettings>();
            UpdateCurrentVitalValue();
            gsScript.SaveCharacterData();
            Application.LoadLevel("mainGame");
        }
    }
    private void DisplayCreateLabel()
    {
        GUI.Label(new Rect(Screen.width / 2 - 50, STARTING_POS + (10 * LINE_HEIGHT), STAT_LABEL_WIDTH, LINE_HEIGHT), "Enter Name");
    }
    private void UpdateCurrentVitalValue()
    {
        for (int i = 0; i < Enum.GetValues(typeof(VitalName)).Length; i++)
        {
            _toon.GetVital(i).CurrentValue = _toon.GetVital(i).AdjustedBaseValue;
        }
    }
}
