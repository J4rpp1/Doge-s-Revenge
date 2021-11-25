using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerHp playerHp;
    public int dealDamage = 1;
    public Rigidbody item;

    private void Awake()
    {
        playerHp = FindObjectOfType<PlayerHp>();
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
    
}
