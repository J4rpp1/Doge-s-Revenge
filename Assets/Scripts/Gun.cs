using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody projectile;
    public float speed = 20;
    public float fireRate = 0.2f;
    [HideInInspector] public bool canFire;
    


    private void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine(FireRate());
            
        }
    }

    IEnumerator FireRate()
    {
        canFire = false;
        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
