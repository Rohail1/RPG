using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targeting : MonoBehaviour {

    public List<Transform> enemies;
    public Transform selectedTarget;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        enemies = new List<Transform>();
        selectedTarget = null;
        myTransform = transform;
        AddAllEnemies();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            TargetEnemy();
        }

	}
    public void AddAllEnemies()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in go)
        {
            AddTarget(enemy.transform);
        }
    }

    public void AddTarget(Transform t)
    {
        enemies.Add(t);
    }

    private void TargetEnemy()
    {
        if (selectedTarget == null)
        {
            SortEnemyByDistance();
            selectedTarget = enemies[0];
        }
        else
        {
            int index = enemies.IndexOf(selectedTarget);
            if (index < enemies.Count -1)
            {
                index++;
            }
            else
            {
                index = 0;
            }
            DeselectTarget();
            selectedTarget = enemies[index];
        }
        SelectTarget();
    }

    private void SortEnemyByDistance()
    {
        enemies.Sort(delegate (Transform t1, Transform t2)
        {
            return (Vector3.Distance(t1.position, myTransform.position).CompareTo(Vector3.Distance(t2.position, myTransform.position)));
        }
        );
    }
    private void SelectTarget()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.red;
        PlayerAttack pa = (PlayerAttack)GetComponent<PlayerAttack>();
        pa.target = selectedTarget.gameObject;
    }
    private void DeselectTarget()
    {
        selectedTarget.GetComponent<Renderer>().material.color = Color.blue;
        selectedTarget = null;
    }
}
