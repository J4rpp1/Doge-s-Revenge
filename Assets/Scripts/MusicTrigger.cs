using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
	[Header("0 = intro")]
	[Header("1 = explore music")]
	[Header("2 = action music ")]
	[SerializeField] bool playMusicInStart;
	[SerializeField] int musicChoice;
	void Start()
	{
		if(playMusicInStart)
		{
			PersistentMusic.Instance.ChooseMusic(musicChoice);
		}
	}

	public void ChooseMusic(int choice)
	{
		PersistentMusic.Instance.ChooseMusic(choice);
	}

}
