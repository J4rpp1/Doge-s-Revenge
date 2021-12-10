using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    PlayerMoney playermoney;
    public int coinBonus = 1;
   
    private void Awake()
    {
        playermoney = FindObjectOfType<PlayerMoney>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerMoney.instance.PickupSound();
            playermoney.moneyCount = playermoney.moneyCount + coinBonus;
            Destroy(gameObject);
        }
    }
}
