using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class Churner : MonoBehaviour
{
    bool churning = false;
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
	float churnDelay; //seconds between spewing out coins
	[SerializeField]
	float initialDelay; //seconds before starting spewing
	float churnTimer;
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
        if (!churning && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Coin churner activated!");
			churning = true;
			anim.SetBool("ChurnerAnimating", true);
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
