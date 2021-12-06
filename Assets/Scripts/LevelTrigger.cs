using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
	[SerializeField]
	string sceneToLoad;
	[SerializeField]
	string sceneToUnload;
	[SerializeField]
	GameObject[] triggersToActivate;
	[SerializeField]
	GameObject[] triggersToDeactivate;
	[SerializeField]
	bool startInactive;
	void Start()
	{
		if(startInactive)
		{
			gameObject.SetActive(false);
		}
	}

	
	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//Load additively, disable to prevent duplicate loading
			if(sceneToLoad != "")
			{
				SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
			}
			if(sceneToUnload != "")
			{
				SceneManager.UnloadSceneAsync(sceneToUnload);
			}
			if(triggersToActivate != null)
			{
				foreach (GameObject trigger in triggersToActivate)
				{
					trigger.SetActive(true);
				}
			}
			if(triggersToDeactivate != null)
			{
				foreach (GameObject trigger in triggersToDeactivate)
				{
					trigger.SetActive(false);
				}
			}
			gameObject.SetActive(false);
		}
	}
}
