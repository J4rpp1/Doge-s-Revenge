using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public Animator animator;
    private bool canMelee;
    Collider m_Collider;
    public Rigidbody item;
    public Transform meleePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        canMelee = true;
        m_Collider = GetComponent<Collider>();
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
        Instantiate(projectile,meleePoint.position, Quaternion.identity);
        //Collider.enabled = true;

        /*Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHp>().Damage();
        }*/

        yield return new WaitForSeconds(0.6f);
        canMelee = true;
        //Collider.enabled = false;
    }
   /*private void OnCollisionEnter(Collision hitInfo) //using parameter Collision instead of Collider to use GetContact
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.Damage();
            Debug.Log("MeleeOssuu");
           // Instantiate(item, transform.position, transform.rotation); //primary particles now spawned when enemy is damaged
        }
        var firstContact = hitInfo.GetContact(0); //Get info from first contact event that happens
        Instantiate(splashParticles, firstContact.point, Quaternion.LookRotation(firstContact.normal, Vector3.up));
    }*/

      /*  private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }*/

}
