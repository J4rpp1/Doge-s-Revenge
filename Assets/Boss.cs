using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Transform target;
    public string playerTag = "Player";
    public Animator animator;

    public Rigidbody meleeEnemy;

    public Transform enemyPosition;
    public Transform enemyPosition2;
    public Transform enemyPosition3;

    [Header("Muokkaa ampumista")]
    public float range = 50f;
    public float fireRate = 0.3f;
    private float fireCountdown = 0f;
    public float speed = 20f;

    public bool canShoot;

    public Transform partToRotate;
    public float turnSpeed = 5f;

    public Rigidbody bulletPrefab;
    public Transform shootPosition;
    void Start()
    {
        
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

        if (fireCountdown <= 0f && canShoot == true)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {

        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);
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


    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);
        canShoot = true;

        yield return new WaitForSeconds(3);
        canShoot = false;
        Debug.Log("hyökkää");
        int EnemyAmount = Random.Range(1, 3);
        for (int i = 0; i < EnemyAmount; i++)
            Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
        int EnemyAmount2 = Random.Range(1, 3);
        for (int i = 0; i < EnemyAmount2; i++)
            Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
        int EnemyAmount3 = Random.Range(1, 3);
        for (int i = 0; i < EnemyAmount3; i++)
            Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);
        var Seconds = Random.Range(5, 20);

        yield return new WaitForSeconds(Seconds);

        int EnemyAmount4 = Random.Range(1, 4);
        for (int i = 0; i < EnemyAmount4; i++)
            Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
        int EnemyAmount5 = Random.Range(1, 2);
        for (int i = 0; i < EnemyAmount5; i++)
            Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
        int EnemyAmount6 = Random.Range(1, 3);
        for (int i = 0; i < EnemyAmount6; i++)
            Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);

        yield return new WaitForSeconds(5);

        canShoot = true;
        animator.SetTrigger("Attack");
        yield return new WaitForSeconds(16);
        animator.ResetTrigger("Attack");
        canShoot = false;

    }


    void Shoot()
    {
        
        Rigidbody instantiatedProjectile = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }
}
