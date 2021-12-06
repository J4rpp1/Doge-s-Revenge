using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDrop : MonoBehaviour
{
    Gun gun;
    public int ammoBonus = 15;
    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gun.ammoCount = gun.ammoCount + ammoBonus;
            Destroy(gameObject);
        }
    }
}
