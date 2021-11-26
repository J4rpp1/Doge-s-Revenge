using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Gun gun;
    public int ammoBonus = 15;
    // Start is called before the first frame update
    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {
            gun.ammoCount = gun.ammoCount + ammoBonus;
            Destroy(gameObject);
        }
    }
}
