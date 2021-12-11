using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPlatform : MonoBehaviour
{
	[SerializeField] GameObject PortalEffect;
	[SerializeField] GameObject lights;
	[SerializeField] Collider EndTrigger;
	[SerializeField] int maxSockets = 5;
	[SerializeField] bool startActive;
	int activeSockets;
	MeshRenderer light_rend;
	[SerializeField] Material hotMaterial;

	void Start()
	{
		light_rend = lights.GetComponent<MeshRenderer>();
		if(startActive)
			Activate();
	}
	
	public void Overcharge() //when a socket adjacent to the platform gets lit up, it adds to a counter. when all sockets are lit up, the portal activates
	{
		activeSockets++;
		if(activeSockets == maxSockets)
			Activate();
		if(activeSockets > maxSockets)
			Debug.LogWarning(this.gameObject+" has more active active sockets than max sockets active, this should never happen!");
	}

	void Activate()
	{
		light_rend.material = hotMaterial;
		PortalEffect.SetActive(true);
		EndTrigger.enabled = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			//ensure player is not dead?
			Debug.Log("End portal triggered!");
			SceneManager.LoadScene("BossFight");
		}
	}
}
