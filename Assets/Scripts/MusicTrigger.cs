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
			switch (musicChoice)
			{
				case 0:
					PersistentMusic.Instance.PlayIntroMusic();
					break;
				case 1:
					PersistentMusic.Instance.PlayExploreMusic();
					break;
				case 2:
					PersistentMusic.Instance.PlayActionMusic();
					break;
				default:
					Debug.LogWarning("MusicTrigger has no music choice set");
					break;
			}
		}
    }

}
