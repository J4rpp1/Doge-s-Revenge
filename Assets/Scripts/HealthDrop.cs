using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDrop : MonoBehaviour
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
        private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
		{
			if (playerHp.currentHP < playerHp.maxHP && canCollect)
			{
				canCollect = false;
				playerHp.currentHP = playerHp.currentHP + healthBonus;
				Destroy(gameObject);
			}
		}
	}
}