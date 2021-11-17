using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemey in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
