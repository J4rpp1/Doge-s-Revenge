using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurnerWire : MonoBehaviour, IHeatable
{
	public float wireHeat;
	[SerializeField] GameObject wireSteamObject;
	[SerializeField] bool haveParticles = true;
	ParticleSystem wireSteam;
	bool turnUpHeat;
	public Component[] meshRenderers;
	float heatSpeed = .2f;
	float hot = 1f;
	float temperature = 0f; //internal variable
	


	void Start()
	{
		if(haveParticles)
			wireSteam = wireSteamObject.GetComponent<ParticleSystem>();
		meshRenderers = GetComponentsInChildren<MeshRenderer>();
	}

	public void Heat()
	{
		if(haveParticles)
			wireSteam.Play();
		turnUpHeat = true;
	}
	public void PreHeat()
	{
		if(haveParticles)
			wireSteam.Play();
		turnUpHeat = true;
		temperature = hot;
	}
	void Update()
	{
		if(turnUpHeat)
		{
			temperature = Mathf.MoveTowards(temperature, hot, heatSpeed * Time.deltaTime);
			SetTemperature();
			if(temperature == hot)
				turnUpHeat = false;
		}
	}

	private void SetTemperature()
	{
		foreach (MeshRenderer rend in meshRenderers)
		{
			rend.material.SetFloat("ColdToHot", temperature); //sets temperature of first material of every mesh renderer. probably not optimized.

		}
	}
}
