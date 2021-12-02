using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danger : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 1;
    private bool damaging;
    private bool stopDamaging;
    // Start is called before the first frame update
    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
        damaging = false;

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && !damaging)
        {
           // playerHp.currentHP = playerHp.currentHP - dealDamage;
            stopDamaging = false;
           StartCoroutine(Damage());
            Debug.Log("osuu");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            
            stopDamaging = true;
            damaging = false;

        }
    }


    IEnumerator Damage()
    {
        while (stopDamaging == false)
               {
            damaging = true;
            playerHp.currentHP = playerHp.currentHP - dealDamage;
            yield return new WaitForSeconds(1);
            damaging = false;
            Debug.Log("Loppu");
        }
        
    }
}
