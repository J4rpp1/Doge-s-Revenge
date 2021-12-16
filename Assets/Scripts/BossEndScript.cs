using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossEndScript : MonoBehaviour
{
	[SerializeField] float SecondsToEndLevel = 6f;
	void Start()
	{
		StartCoroutine(WaitForEnd()); //Called by the boss ship wreckage. Creates a simple delay before moving to end scene.
	}

	// Update is called once per frame
	IEnumerator WaitForEnd()
	{
        yield return new WaitForSeconds(SecondsToEndLevel);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
