using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    PlayerHp playerHP;

    [SerializeField]
    public AudioSource shootSound;
    public AudioSource noAmmo;
    public AudioSource collect;
   
    
    
    
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
        playerHP = FindObjectOfType<PlayerHp>();
        instance = this;
    }

    private void Start()
    {
       
        
        canFire = true;
        
       ammoCount = PlayerPrefs.GetInt("Ammo", ammoCount);
    }

    public void PickupSound()
    {
        collect.Play();
        
    }

    void Update()
    {
        ammoText.text = "Ammo " + ammoCount.ToString();
        if (Input.GetButton("Fire1") && canFire && ammoCount > 0 && PauseMenu.isPaused == false == ShopMenu.shopActive == false && playerHP.isDead == false)
        {
            StartCoroutine(FireRate());
            
        }
        if(Input.GetButton("Fire1") && canFire && ammoCount < 1 && PauseMenu.isPaused == false == ShopMenu.shopActive == false && playerHP.isDead == false)
        {
            Debug.Log("EI ammuksia");
            StartCoroutine(NoAmmo());
        }
    }

    IEnumerator FireRate()
    {
        canFire = false;
        ammoCount -= 1;
        shootSound.Play();
        Rigidbody instantiatedProjectile = Instantiate(projectile, shootPosition.position, shootPosition.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    IEnumerator NoAmmo()
    {
        canFire = false;
        noAmmo.Play();
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
