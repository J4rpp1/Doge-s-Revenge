using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticles : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine("Destroy");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
}
