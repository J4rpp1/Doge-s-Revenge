using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
	[Header("0 = intro")]
	[Header("1 = explore music")]
	[Header("2 = action music ")]
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

		musicSource = GetComponent<AudioSource>();
	}

/* 	void Start()
	{

	} */

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
	
	public void ChooseMusic(int musicChoice)
	{
		switch (musicChoice)
		{
			case 0:
				PlayIntroMusic();
				break;
			case 1:
				PlayExploreMusic();
				break;
			case 2:
				PlayActionMusic();
				break;
			default:
				Debug.LogWarning("MusicTrigger has no music choice set");
				break;
		}
	}

	void Update()
	{
		if(!musicSource.isPlaying)
		{
			PlayExploreMusic(); //just play the exploration music as fallback whenever a song runs out.
		}
	}
}
