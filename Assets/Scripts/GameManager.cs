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
		Debug.Log(gameObject+" becometh instance of GameManager");
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
        PlayerPrefs.SetFloat("X", newPosition.x);
        PlayerPrefs.SetFloat("Y", newPosition.y);
        PlayerPrefs.SetFloat("Z", newPosition.z);
		Debug.Log("Saved location at "+PlayerPrefs.GetFloat("X")+", "+PlayerPrefs.GetFloat("Y")+", "+PlayerPrefs.GetFloat("Z"));
    }
    public Vector3 GetSpawnPoint() // This method is identical to one below, but this one does not work. True madness.
    {
		Vector3 savePos = new Vector3(
			PlayerPrefs.GetFloat("X"), 
			PlayerPrefs.GetFloat("Y"), 
			PlayerPrefs.GetFloat("Z"));
		Debug.Log("Loaded save location at "+PlayerPrefs.GetFloat("X")+", "+PlayerPrefs.GetFloat("Y")+", "+PlayerPrefs.GetFloat("Z"));
		return savePos;
    }
    public Vector3 GetStartPoint()
    {
		Vector3 savePos = new Vector3(
			PlayerPrefs.GetFloat("X"), 
			PlayerPrefs.GetFloat("Y"), 
			PlayerPrefs.GetFloat("Z"));
		Debug.Log("Loaded save location at "+PlayerPrefs.GetFloat("X")+", "+PlayerPrefs.GetFloat("Y")+", "+PlayerPrefs.GetFloat("Z"));
		return savePos;
    }
}
