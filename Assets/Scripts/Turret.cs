using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
	private GameObject[] players;
	Vector3 aimVerticalOffset;
   

    [Header("Muokkaa ampumista")]
    public float range = 15f;
    public float fireRate = 0.3f;
    private float fireCountdown = 0f;
    public float speed = 20f;
	[SerializeField] float aimVerticalOffsetMultiplier = 1f;


    [Header("Muista")]
    public string playerTag = "Player";

    public Transform partToRotate;
    public float turnSpeed = 5f;

    public Rigidbody bulletPrefab;
    public Transform shootPosition;

    [Header("Linecast")]
	[SerializeField] LayerMask lineMask;
    
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
		aimVerticalOffset = Vector3.up * aimVerticalOffsetMultiplier;
        
    }

    void UpdateTarget ()
    {

        
		players = GameObject.FindGameObjectsWithTag(playerTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;
        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }
        if (nearestPlayer != null && shortestDistance <= range)
        {
            target = nearestPlayer.transform;
        }
        else
        {
            target = null;
        }
    }

   
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position + aimVerticalOffset - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler (rotation.x, rotation.y, 0f);


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
		RaycastHit hit;
		if (!Physics.Linecast(transform.position, target.position + aimVerticalOffset, out hit, lineMask))
		{
			Rigidbody instantiatedProjectile = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation) as Rigidbody;
			instantiatedProjectile.velocity = (target.position + aimVerticalOffset - shootPosition.position).normalized * speed;
			Debug.DrawLine(transform.position, target.position + aimVerticalOffset, Color.blue, 1f);

		}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
