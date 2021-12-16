using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    GameManager theGameManager;
	ParticleSystem saveParticles;
    Gun gun;


    void Start()
    {
        theGameManager = FindObjectOfType<GameManager>();
		saveParticles = GetComponentInChildren<ParticleSystem>();
        gun = FindObjectOfType<Gun>();
    }

   
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("Ammo", gun.ammoCount);
            theGameManager.SetSpawnPoint(transform.position);
            theGameManager.x = transform.position.x;
            theGameManager.y = transform.position.y;
            theGameManager.z = transform.position.z;
			saveParticles.Play();
        }
    }
}
