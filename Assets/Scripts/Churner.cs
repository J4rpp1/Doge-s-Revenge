using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class Churner : MonoBehaviour
{
    bool churning = false;
	public AudioSource churmingSound;
	[SerializeField]
	Transform coinSpawnPoint;
	[SerializeField]
	Rigidbody coinPrefab;
	[SerializeField]
	GameObject smokeObject;
	[SerializeField]
	int coinsToSpawn;
	[SerializeField]
	float coinSpeed;
	[SerializeField]
	GameObject[] heatableObjects; //Every object connected to the churner that will we heated by it, such as wires and ice walls.
	[SerializeField]
	float churnDelay; //seconds between spewing out coins
	[SerializeField]
	float initialDelay; //seconds before starting spewing
	float churnTimer; //internal counter
	Animator anim;
	ParticleSystem smokeParticles;
    void Start()
    {
        churnTimer = initialDelay;
		anim = GetComponent<Animator>();
		smokeParticles = smokeObject.GetComponent<ParticleSystem>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (!churning && other.gameObject.CompareTag("Player")) //placeholder: Activate churner when player touches a trigger
		{
			ActivateChurner();
		}
	}

	private void ActivateChurner()
	{
		Debug.Log("Coin churner activated!");
		churning = true;
		anim.SetBool("ChurnerAnimating", true);
		churmingSound.Play();
		foreach (GameObject heatableObject in heatableObjects)
		{
			heatableObject.GetComponent<IHeatable>().Heat(); //Using an interface, Heat() all objects in array
		}
	}

	void Update()
	{
		if(churning && coinsToSpawn > 0)
		{
			churnTimer-=Time.deltaTime;
			SpawnCoin();
			StartParticles();
		}
	}

	void SpawnCoin()
	{
		if(churnTimer < 0f)
		{
			Rigidbody instantiatedProjectile = Instantiate(coinPrefab, coinSpawnPoint.position, Quaternion.identity) as Rigidbody;
			instantiatedProjectile.velocity = (Random.onUnitSphere + coinSpawnPoint.TransformDirection(new Vector3(0, 0, coinSpeed)));
			churnTimer = churnDelay;
			coinsToSpawn--;
		}
	}
	void StartParticles()
	{
		if(!smokeParticles.isPlaying)
		smokeParticles.Play();
	}
}
