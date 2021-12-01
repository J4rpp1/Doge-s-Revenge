using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameManager theGameManager;


    
    void Start()
    {
        theGameManager = FindObjectOfType<GameManager>();
    }

   
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            theGameManager.SetSpawnPoint(transform.position);
            theGameManager.x = transform.position.x;
            theGameManager.y = transform.position.y;
            theGameManager.z = transform.position.z;
        }
    }
}
