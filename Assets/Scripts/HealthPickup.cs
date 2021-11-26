using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    PlayerHp playerHp;
    public bool canCollect;
    public int healthBonus = 1;
    private void Awake()
    {
        canCollect = true;
        playerHp = FindObjectOfType<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (playerHp.currentHP < playerHp.maxHP && canCollect)
        {
            canCollect = false;
            playerHp.currentHP = playerHp.currentHP + healthBonus;
            Destroy(gameObject);
        }
    }
}