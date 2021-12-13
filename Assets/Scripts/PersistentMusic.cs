using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
	private static PersistentMusic _instance;
	public static PersistentMusic Instance { get { return _instance; } }
	[SerializeField] public AudioClip exploreMusic;
	[SerializeField] public AudioClip actionMusic;
	[SerializeField] public AudioClip introMusic;

	AudioSource musicSource;

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
	{
		musicSource = GetComponent<AudioSource>();
	}

	public void PlayExploreMusic()
	{
		musicSource.Stop();
		musicSource.PlayOneShot(exploreMusic);
	}
	public void PlayActionMusic()
	{
		musicSource.Stop();
		musicSource.PlayOneShot(actionMusic);
	}	
	public void PlayIntroMusic()
	{
		musicSource.Stop();
		musicSource.PlayOneShot(introMusic);
	}	
	void Update()
	{
		if(!musicSource.isPlaying)
		{
			PlayExploreMusic(); //just play the exploration music as fallback whenever a song runs out.
		}
	}
}
