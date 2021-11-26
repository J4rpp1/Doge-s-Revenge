using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 1;
    public Rigidbody item;

   
    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
        StartCoroutine(Destroy());

    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player")
            {
                playerHp.currentHP = playerHp.currentHP - dealDamage;
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