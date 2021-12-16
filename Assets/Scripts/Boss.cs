using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour, IDamageable
{
    [Header("HP")]
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int damage = 50;
    public bool canTakeDamage;
    public Animator hpAnimation;

    [Header("Other")]
    private Transform target;
    public string playerTag = "Player";
    public Animator animator;
	[SerializeField] GameObject bossShieldCollider;
	[SerializeField] GameObject bossShield;
	MeshRenderer bossShield_rend;
	Collider bossBodyCollider;
	[SerializeField] float aimVerticalOffsetMultiplier = 1f;
	Vector3 aimVerticalOffset;
	[SerializeField] GameObject wreckPrefab;

    [Header("Enemies")]
    public GameObject meleeEnemy;
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

    [Header("CoinPrefabs")]
    public Rigidbody coinPrefab;
    public Transform coinPosition;
    public Transform coinPosition2;
    public Transform coinPosition3;
    
    
    void Start()
    {
		bossShield_rend = bossShield.GetComponent<MeshRenderer>();
		bossBodyCollider = GetComponent<SphereCollider>();
		aimVerticalOffset = Vector3.up * aimVerticalOffsetMultiplier;

        canTakeDamage = false;
		bossShield_rend.enabled = true;
		bossShieldCollider.SetActive(true);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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


    #region Target
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
    #endregion

    #region AttackSequence
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            canShoot = true;
            hpAnimation.SetTrigger("BlockDisable");
            Vulnerable(true);

            yield return new WaitForSeconds(4);
            hpAnimation.ResetTrigger("BlockDisable");
            canShoot = false;
            yield return new WaitForSeconds(0.1f);
            Vulnerable(false);
            hpAnimation.SetTrigger("BlockEnable");


            //Debug.Log("hy�kk��");
            int EnemyAmount = Random.Range(1, 1);
            for (int i = 0; i < EnemyAmount; i++)
                Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
            int EnemyAmount2 = Random.Range(1, 3);
            for (int i = 0; i < EnemyAmount2; i++)
                Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
            int EnemyAmount3 = Random.Range(1, 2);
            for (int i = 0; i < EnemyAmount3; i++)
                Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);
            var Seconds = Random.Range(5, 15);

            yield return new WaitForSeconds(Seconds);

            int EnemyAmount4 = Random.Range(1, 2);
            for (int i = 0; i < EnemyAmount4; i++)
                Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
            int EnemyAmount5 = Random.Range(1, 2);
            for (int i = 0; i < EnemyAmount5; i++)
                Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
            int EnemyAmount6 = Random.Range(1, 2);
            for (int i = 0; i < EnemyAmount6; i++)
                Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);

            yield return new WaitForSeconds(6);
            hpAnimation.ResetTrigger("BlockEnable");
            hpAnimation.SetTrigger("BlockDisable");
            Vulnerable(true);
            canShoot = true;
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(16);
            hpAnimation.ResetTrigger("BlockDisable");
            yield return new WaitForSeconds(0.1f);
            animator.ResetTrigger("Attack");
            canShoot = false;
            Vulnerable(false);
            hpAnimation.SetTrigger("BlockEnable");

            yield return new WaitForSeconds(1);

            hpAnimation.ResetTrigger("BlockEnable");
            int EnemyAmount7 = Random.Range(1, 4);
            for (int i = 0; i < EnemyAmount7; i++)
                Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
            int EnemyAmount8 = Random.Range(2, 3);
            for (int i = 0; i < EnemyAmount8; i++)
                Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
            int EnemyAmount9 = Random.Range(1, 3);
            for (int i = 0; i < EnemyAmount9; i++)
                Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);

            yield return new WaitForSeconds(7);

            hpAnimation.ResetTrigger("BlockEnable");
            hpAnimation.SetTrigger("BlockDisable");
            Vulnerable(true);
            canShoot = true;
            animator.SetTrigger("Attack2");
            yield return new WaitForSeconds(23);
            hpAnimation.ResetTrigger("BlockDisable");
            yield return new WaitForSeconds(0.1f);
            animator.ResetTrigger("Attack2");
            canShoot = false;
            Vulnerable(false);
            hpAnimation.SetTrigger("BlockEnable");

            yield return new WaitForSeconds(2);


            
            for (int i = 0; i < EnemyAmount7; i++)
                Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
            
            for (int i = 0; i < EnemyAmount8; i++)
                Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
           
            for (int i = 0; i < EnemyAmount9; i++)
                Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);



            
            yield return new WaitForSeconds(2);
            yield return 0;
        }
        

    }


    void Shoot()
    {
        
        /* Rigidbody instantiatedProjectile = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed)); */
		Rigidbody instantiatedProjectile = Instantiate(bulletPrefab, shootPosition.position, shootPosition.rotation) as Rigidbody;
		instantiatedProjectile.velocity = (target.position + aimVerticalOffset - shootPosition.position).normalized * speed;
    }
    #endregion

    #region HP
    public void Damage()
    {
        if (canTakeDamage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

	void Vulnerable(bool vulnerable)
	{
		if(vulnerable)
		{
            canTakeDamage = true;
			bossShield_rend.enabled = false;
			bossBodyCollider.enabled = true;
			bossShieldCollider.SetActive(false);
		}
		else
		{
            canTakeDamage = false;
			bossShield_rend.enabled = true;
			bossBodyCollider.enabled = false;
			bossShieldCollider.SetActive(true);
		}
	}	

    void Die()
    {



        var CoinAmount = Random.Range(10, 20);
        for (var i = 0; i < CoinAmount; i++)
            Instantiate(coinPrefab, coinPosition.position, Quaternion.identity);
        var CoinAmount2 = Random.Range(2, 10);
        for (var i = 0; i < CoinAmount2; i++)
            Instantiate(coinPrefab, coinPosition2.position, Quaternion.identity);
        var CoinAmount3 = Random.Range(2, 10);
        for (var i = 0; i < CoinAmount3; i++)
            Instantiate(coinPrefab, coinPosition3.position, Quaternion.identity);

		Instantiate(wreckPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    #endregion
}
