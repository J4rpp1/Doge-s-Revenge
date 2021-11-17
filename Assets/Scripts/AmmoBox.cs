using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Gun gun;
    public int ammoBonus = 15;
    // Start is called before the first frame update
    private void awake()
    {
        gun = FindObjectOfType<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        gun.ammoCount = gun.ammoCount + ammoBonus;
        Destroy(gameObject);
    }
}
