using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage = 100;
    public float hitPoint;
    public Rigidbody item;

    private void Start()
    {
        StartCoroutine("Destroy");
    }
    private void OnTriggerEnter(Collider hitInfo)
    {
        EnemyHp enemy = hitInfo.GetComponent<EnemyHp>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Instantiate(item, transform.position,transform.rotation);
        
        Destroy(gameObject);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
