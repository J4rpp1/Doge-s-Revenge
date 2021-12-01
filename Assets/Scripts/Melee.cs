using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public Animator animator;
    private bool canMelee;
    
    // Start is called before the first frame update
    void Start()
    {
        canMelee = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && canMelee)
        {
           StartCoroutine (Attack());
        }
    }

    IEnumerator Attack()
    {
        canMelee = false;
        animator.SetTrigger("Attack");

        /*Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHp>().Damage();
        }*/
        
        yield return new WaitForSeconds(0.6f);
        canMelee = true;
    }
    private void OnCollisionEnter(Collision hitInfo) //using parameter Collision instead of Collider to use GetContact
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage();
            Debug.Log("osuu");
            //Instantiate(item, transform.position, transform.rotation); //primary particles now spawned when enemy is damaged
        }
    }

      /*  private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/
}
