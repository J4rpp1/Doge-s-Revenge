using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danger : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playerHp.currentHP = playerHp.currentHP - dealDamage;
        }
    }
}
