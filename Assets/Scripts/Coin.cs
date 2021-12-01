using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    PlayerMoney playermoney;
    public int coinBonus = 1;
    public Rigidbody rb;
    Collider m_Collider;
	[SerializeField]
	float coinFreezeTime;
    private void Awake()
    {
        m_Collider = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        playermoney = FindObjectOfType<PlayerMoney>();
        StartCoroutine(StopGravity());
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            playermoney.moneyCount = playermoney.moneyCount + coinBonus;
            Destroy(gameObject);
        }
    }

    IEnumerator StopGravity()
    {
        yield return new WaitForSeconds(coinFreezeTime);
        m_Collider.enabled = !m_Collider.enabled;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
    }
}
