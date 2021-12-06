using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	Animator anim; 
	[SerializeField]
	GameObject gunMesh;
	[SerializeField]
	Transform cameraPivot;
	[SerializeField]
	bool forceGunIntoHand;
	[SerializeField]
	Transform handBone;
	float cameraInclination;
	float maxCameraAngle = 60f; //this should always correspond to max and min camera angles
	
	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		anim.SetLayerWeight(1, 1f); //Aim layer remains active when player has control of the weapon
	}
	void Update()
	{
		if(forceGunIntoHand)
		PutGunInHand();

 		cameraInclination = cameraPivot.eulerAngles.x;
		if(cameraPivot.eulerAngles.x > maxCameraAngle + 1f) // +1f for safety margin
			cameraInclination = cameraPivot.eulerAngles.x - 360f; // camera Transform pitch jumps over to 360 below 0 so we need to subtract to get it into 60 to -60 range
		anim.SetFloat("AimInclination", cameraInclination / maxCameraAngle); // remap from "60 to -60" to "1 to -1"
		

	}

	void PutGunInHand() //This is done to prevent inherited scale from animation. Easier than resetting global scale.
	{
		gunMesh.transform.position = handBone.position;
		gunMesh.transform.rotation = handBone.rotation; //Rotation would be handled by Animation Rigging m_GunAim if it worked
	}
}
