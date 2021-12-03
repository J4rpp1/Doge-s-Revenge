using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
    public Rigidbody meleeEnemy;

    public Transform enemyPosition;
    public Transform enemyPosition2;
    public Transform enemyPosition3;
    void Start()
    {
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Attack()
    {
        Debug.Log("hyökkää");
        int EnemyAmount = Random.Range(1, 2);
        for (int i = 0; i < EnemyAmount; i++)
            Instantiate(meleeEnemy, enemyPosition.position, Quaternion.identity);
        int EnemyAmount2 = Random.Range(1, 2);
        for (int i = 0; i < EnemyAmount2; i++)
            Instantiate(meleeEnemy, enemyPosition2.position, Quaternion.identity);
        int EnemyAmount3 = Random.Range(1, 2);
        for (int i = 0; i < EnemyAmount3; i++)
            Instantiate(meleeEnemy, enemyPosition3.position, Quaternion.identity);
        var Seconds = Random.Range(5, 20);

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
        

    }

}
