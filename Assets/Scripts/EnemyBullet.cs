using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 1;
    public Transform item;

   
    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
        StartCoroutine(Destroy());

    }

    private void OnTriggerEnter(Collider other)
        {
        if (other.name == "Player" && playerHp.canTakeDamage == true)
            {
                playerHp.currentHP = playerHp.currentHP - dealDamage;
                playerHp.canTakeDamage = false;
            }
        Instantiate(item, transform.position, transform.rotation);

        Destroy(gameObject);
        }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
