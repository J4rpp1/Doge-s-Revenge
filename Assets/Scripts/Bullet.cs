using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 100;
    private void OnTriggerEnter(Collider hitInfo)
    {
        EnemyHp enemy = hitInfo.GetComponent<EnemyHp>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
