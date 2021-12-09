using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurnerWire : MonoBehaviour, IHeatable
{
	public float wireHeat;
	[SerializeField]
	GameObject wireSteamObject;
	ParticleSystem wireSteam;
	bool turnUpHeat;
	public Component[] meshRenderers;
	float heatSpeed = .2f;
	float hot = 1f;
	float temperature = 0f; //internal variable
	


	void Start()
	{
		wireSteam = wireSteamObject.GetComponent<ParticleSystem>();
		meshRenderers = GetComponentsInChildren<MeshRenderer>();
	}

	public void Heat()
	{
		wireSteam.Play();
		turnUpHeat = true;
	}
	void Update()
	{
		if(turnUpHeat)
		{
			temperature = Mathf.MoveTowards(temperature, hot, heatSpeed * Time.deltaTime);
			SetTemperature();
			if(temperature == hot)
				turnUpHeat = false;
				Debug.Log("wire heating complete");
		}
	}

	private void SetTemperature()
	{
		foreach (MeshRenderer rend in meshRenderers)
		{
			rend.material.SetFloat("ColdToHot", temperature); //sets temperature of first material of every mesh renderer. probably not optimized.
			Debug.Log("temperature: "+temperature);

		}
	}
}
