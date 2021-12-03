using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBox : MonoBehaviour, IDamageable
{

    public int damage = 100;
    public int maxHealth = 100;
    public int currentHealth;

    public float speed = 1f;

    public Transform coinPosition;
    public Transform coinPosition2;
    public Transform ammoBoxPosition;
    public Rigidbody coinPrefab;
    public Rigidbody ammoBoxPrefab;
    void Start()
    {
        currentHealth = maxHealth;
    }

    

    public void Damage()
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        var CoinAmount = Random.Range(1, 4);
        for (var i = 0; i < CoinAmount; i++)
            Instantiate(coinPrefab, coinPosition.position, Quaternion.identity);
        var CoinAmount2 = Random.Range(1, 4);
        for (var i = 0; i < CoinAmount2; i++)
            Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity);
        var AmmoAmount = Random.Range(0, 2);
        for (var i = 0; i < AmmoAmount; i++)
            Instantiate(ammoBoxPrefab, ammoBoxPosition.position, Quaternion.identity);
        //instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));



        Destroy(gameObject);
    }

   

}
