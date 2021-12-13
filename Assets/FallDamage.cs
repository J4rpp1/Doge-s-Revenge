using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 10;
    // Start is called before the first frame update
    void Start()
    {
        playerHp = FindObjectOfType<PlayerHp>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" )
        {
            
            playerHp.currentHP = playerHp.currentHP - dealDamage;
            

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
