using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int curHealth = 100;
    public float healthBarLength;
    // Use this for initialization
    void Start()
    {
        healthBarLength = Screen.width / 2;
    }

    // Update is called once per frame
    void Update()
    {
        AdjustHealthBar(0);
    }
    void OnGUI()
    {
        GUI.Box(new Rect(20, 45, healthBarLength, 20), curHealth + "/" + maxHealth);
    }
    public void AdjustHealthBar(int adj)
    {
        curHealth += adj;
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth < 0)
        {
            curHealth = 0;
        }
        healthBarLength = (Screen.width / 2) * (curHealth / (float)maxHealth);
    }
}
