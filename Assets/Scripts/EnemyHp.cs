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
	public GameObject corpsePrefab;
	public GameObject destroyOnDeath;
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
	   


		var CoinAmount = Random.Range(0, 2);
		for (var i = 0; i < CoinAmount; i++)
			Instantiate(coinPrefab, coinPosition.position, Quaternion.identity);
		var CoinAmount2 = Random.Range(1, 4);
		for (var i = 0; i < CoinAmount2; i++)
			Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity);
		var CoinAmount3 = Random.Range(0, 2);
		for (var i = 0; i < CoinAmount3; i++)
			Instantiate(coinPrefab, coinPosition3.position, Quaternion.identity);
		var AmmoAmount = Random.Range(0, 2);
		for (var i = 0; i < AmmoAmount; i++)
			Instantiate(ammoBoxPrefab, ammoBoxPosition.position, Quaternion.identity);

		if (corpsePrefab != null)
			Instantiate(corpsePrefab, transform.position, Quaternion.identity); //Spawn a corpse here
		if (destroyOnDeath != null)
			Destroy(destroyOnDeath); //If script is not on parent object, it may need to be specified to not leave parts of the enemy behind.
		Destroy(gameObject);
	}
	
}
