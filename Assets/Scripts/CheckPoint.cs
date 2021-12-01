using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameManager theGameManager;
    Gun gun;


    void Start()
    {
        theGameManager = FindObjectOfType<GameManager>();
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
        }
    }
}
