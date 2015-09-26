using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
    // Use this for initialization
    public GameObject target;
    public float attackTimer;
    public float cooldown;

    void Start()
    {
        attackTimer = 0;
        cooldown = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        if (attackTimer < 0)
        {
            attackTimer = 0;
        }

  
            if (attackTimer == 0)
            {
                Attack();
                attackTimer = cooldown;
            }

    }
    void Attack()
    {
        float distance = Vector3.Distance(target.transform.position, this.transform.position);
        Vector3 dir = (target.transform.position - this.transform.position).normalized;
        float direction = Vector3.Dot(dir, this.transform.forward);

        if (distance < 2.5)
        {
            if (direction > 0)
            {
                PlayerHealth enemyHealth = (PlayerHealth)target.GetComponent<PlayerHealth>();
                enemyHealth.AdjustHealthBar(-10);

            }
        }

    }
}
