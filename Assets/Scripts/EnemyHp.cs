using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Rigidbody coinPrefab;
    

    public Transform coinPosition;
    public Transform coinPosition2;
    public Transform coinPosition3;
    public float speed = 1f;
    
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
        Rigidbody instantiatedProjectile = Instantiate(coinPrefab, coinPosition.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Rigidbody instantiatedProjectile2 = Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile2.velocity = transform.TransformDirection(new Vector3(1, 1, speed));
        Rigidbody instantiatedProjectile3 = Instantiate(coinPrefab, coinPosition3.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile3.velocity = transform.TransformDirection(new Vector3(-2, -2, speed));

        Destroy(gameObject);
    }
}
