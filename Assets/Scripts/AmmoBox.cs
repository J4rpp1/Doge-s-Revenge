using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    Gun gun;
    public int ammoBonus = 15;
    public Rigidbody rb;
    Collider m_Collider;
    [SerializeField]
    float ammoFreezeTime;
    private void Awake()
    {
        gun = FindObjectOfType<Gun>();
        m_Collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        StartCoroutine(StopGravity());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="Player")
        {
            Gun.instance.PickupSound();
            gun.ammoCount = gun.ammoCount + ammoBonus;
            Destroy(gameObject);
        }
    }

    IEnumerator StopGravity()
    {
        yield return new WaitForSeconds(ammoFreezeTime);
        m_Collider.enabled = !m_Collider.enabled;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }
}
