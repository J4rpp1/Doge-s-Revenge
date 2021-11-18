using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerMoney playermoney;
    public int coinBonus = 1;
    // Start is called before the first frame update
    private void Awake()
    {
        playermoney = FindObjectOfType<PlayerMoney>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playermoney.moneyCount = playermoney.moneyCount + coinBonus;
            Destroy(gameObject);
        }
    }
}
