using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMelt : MonoBehaviour, IHeatable
{
	Animator anim;
	ParticleSystem dropParticles;
	[SerializeField]
	float meltTime = 12f;
	void Start()
	{
		anim = GetComponentInChildren<Animator>();
		dropParticles = GetComponentInChildren<ParticleSystem>();
	}

	// Update is called once per frame
	public void Heat()
	{
		anim.SetTrigger("Melt");
		dropParticles.Play();
		StartCoroutine("Destroy");
	}
	
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(meltTime);
        Destroy(gameObject);
    }
}
