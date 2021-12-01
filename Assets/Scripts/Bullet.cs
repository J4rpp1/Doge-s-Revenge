using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage = 60;
    public float hitPoint;
    public Rigidbody item;
	public Transform splashParticles;

    private void Start()
    {
        StartCoroutine("Destroy");
    }
    private void OnCollisionEnter(Collision hitInfo) //using parameter Collision instead of Collider to use GetContact
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        if(damageable != null)
        {
            damageable.Damage();
            
        	Instantiate(item, transform.position,transform.rotation); //primary particles now spawned when enemy is damaged
        }

        var firstContact = hitInfo.GetContact(0); //Get info from first contact event that happens
		Instantiate(splashParticles, firstContact.point, Quaternion.LookRotation(firstContact.normal, Vector3.up)); //Spawn splashParticles at the point of contact, oriented away from the surface

        Destroy(gameObject);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
