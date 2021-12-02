using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int currentHealth;
    public Rigidbody coinPrefab;
    public Rigidbody ammoBoxPrefab;

    public Transform coinPosition;
    public Transform coinPosition2;
    public Transform coinPosition3;
    public Transform ammoBoxPosition;
    public float speed = 1f;
    public int damage = 50;
    
    void Start()
    {
        currentHealth = maxHealth;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage()
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    
    void Die()
    {
       /* Rigidbody instantiatedProjectile = Instantiate(coinPrefab, coinPosition.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Rigidbody instantiatedProjectile2 = Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile2.velocity = transform.TransformDirection(new Vector3(1, 1, speed));
        Rigidbody instantiatedProjectile3 = Instantiate(coinPrefab, coinPosition3.position, Quaternion.identity) as Rigidbody;
        instantiatedProjectile3.velocity = transform.TransformDirection(new Vector3(-2, -2, speed));*/


        var CoinAmount = Random.Range(0, 2);
        for (var i = 0; i < CoinAmount; i++)
            Instantiate(coinPrefab, coinPosition.position, Quaternion.identity);
        var CoinAmount2 = Random.Range(1, 4);
        for (var i = 0; i < CoinAmount2; i++)
            Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity);
        var CoinAmount3 = Random.Range(0, 2);
        for (var i = 0; i < CoinAmount3; i++)
            Instantiate(coinPrefab, coinPosition3.position, Quaternion.identity);
        var AmmoAmount = Random.Range(0, 1);
        for (var i = 0; i < AmmoAmount; i++)
            Instantiate(ammoBoxPrefab, ammoBoxPosition.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
