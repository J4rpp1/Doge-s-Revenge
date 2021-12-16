using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellOutTrigger : MonoBehaviour
{
	GameObject player;
	PlayerHp playerHp;
	[SerializeField] int dealDamage = 10;
	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerHp = player.GetComponent<PlayerHp>();
	}
	// Update is called once per frame
	void Update()
	{
		if(player.transform.position.y < transform.position.y) // Trigger when player reaches same or lower vertical position
			playerHp.currentHP = playerHp.currentHP - dealDamage; // 10 should be enough to kill any player
	}
}
