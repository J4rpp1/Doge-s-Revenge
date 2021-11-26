using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody projectile;
    public float speed = 20;
    public float fireRate = 0.2f;
    [HideInInspector] public bool canFire;
    public int ammoCount;
    public TMP_Text ammoText;
    public static Gun instance;
    public Transform shootPosition;


    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        canFire = true;
        ammoCount = 50;
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo " + ammoCount.ToString();
        if (Input.GetButton("Fire1") && canFire && ammoCount > 0 && PauseMenu.isPaused == false == ShopMenu.shopActive == false)
        {
            StartCoroutine(FireRate());
            
        }
    }

    IEnumerator FireRate()
    {
        canFire = false;
        ammoCount -= 1;
        Rigidbody instantiatedProjectile = Instantiate(projectile, shootPosition.position, shootPosition.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
