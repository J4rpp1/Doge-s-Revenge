using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;


public class Churner5 : MonoBehaviour
{
    bool churning = false;
	bool canActivate;
	public int save;
	public AudioSource churmingSound;
	[SerializeField] Transform coinSpawnPoint;
	[SerializeField] Rigidbody coinPrefab;
	[SerializeField] GameObject smokeObject;
	[SerializeField] int coinsToSpawn;
	[SerializeField] float coinSpeed;
	[SerializeField] GameObject pressEText;
	[SerializeField] GameObject[] heatableObjects; //Every object connected to the churner that will we heated by it, such as wires and ice walls.
	
	[SerializeField] float churnDelay; //seconds between spewing out coins
	[SerializeField] float initialDelay; //seconds before starting spewing
	float churnTimer; //internal counter
	Animator anim;
	ParticleSystem smokeParticles;
	
    void Start()
    {
		save = PlayerPrefs.GetInt("Save5");
		if(save>1)
        {
			StartCoroutine(Wait());
		}
		churnTimer = initialDelay;
		anim = GetComponent<Animator>();
		smokeParticles = smokeObject.GetComponent<ParticleSystem>();
	 canActivate = false;

    }

    void OnTriggerEnter(Collider other)
    {
        if (!churning && other.gameObject.CompareTag("Player"))
		{
            canActivate = true;
            pressEText.SetActive(true);
		}
	}
    void OnTriggerExit(Collider other)
    {
        if (!churning && other.gameObject.CompareTag("Player"))
		{
            canActivate = false;
            pressEText.SetActive(false);
		}
	}
	private void ActivateChurner()
	{
		Debug.Log("Coin churner activated!");
		churning = true;
		anim.SetBool("ChurnerAnimating", true);
		
		foreach (GameObject heatableObject in heatableObjects)
		{
			heatableObject.GetComponent<IHeatable>().Heat(); //Using an interface, Heat() all objects in array
			PlayerPrefs.SetInt("Save5", 2);
		}
		
	}
	public void StartActive()
	{
		Debug.Log("Coin churner starts activated!");
		churning = true;
		coinsToSpawn = 0;
		anim.SetTrigger("SkipStart");
		//churmingSound.Play();
		foreach (GameObject heatableObject in heatableObjects)
		{
			heatableObject.GetComponent<IHeatable>().PreHeat(); //Using an interface, Heat() all objects in array
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

	if (Input.GetKeyDown(KeyCode.E) && canActivate == true && !churning)
        {
			
			ActivateChurner();
			canActivate = false;
            pressEText.SetActive(false);
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
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(1);
		StartActive();
	}
}
