using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector3 respawnPoint;
    public Transform savePoint;
    public float x;
    public float y;
    public float z;
    public static GameManager instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        /*
        PlayerPrefs.GetFloat("X", x);
        PlayerPrefs.GetFloat("Y", y);
        PlayerPrefs.GetFloat("Z", z);
        savePoint.transform(x, y, z);*/

    }

    
    void Update()
    {
        
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
        /*
        PlayerPrefs.SetFloat("X", x);
        PlayerPrefs.SetFloat("Y", y);
        PlayerPrefs.SetFloat("Z", z);*/




    }




}
