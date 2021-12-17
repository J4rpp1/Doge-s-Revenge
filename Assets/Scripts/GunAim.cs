using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAim : MonoBehaviour
{
	[SerializeField]
	float reticleSpeed = 50f;
	[SerializeField]
	float maxAimRange;
	[SerializeField]
	Transform aimPoint;
	[SerializeField]
	Camera cam;
	[SerializeField]
	LayerMask rayMask;
	[SerializeField]
	RectTransform crosshair;
	[SerializeField]
	bool forceGunIntoHand;
	public bool forceGunAim; //This variable would be controlled by animation keyframes or events
	[SerializeField]
	Transform handBone;
	[SerializeField]
	GameObject gunMesh;
	Vector3 aimDesiredPosition;
	Vector2 crosshairDesiredPosition;
	void FixedUpdate()
	{
		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxAimRange, rayMask))
		{
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
			aimDesiredPosition = hit.point;
		}
		else
		{
			//Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxAimRange, Color.yellow);
			aimDesiredPosition = transform.position + transform.TransformDirection(Vector3.forward) * maxAimRange;
		}
	}
	void Update()
	{
		aimPoint.position = Vector3.Lerp(aimPoint.position, aimDesiredPosition, reticleSpeed * Time.deltaTime); //wrong way to use lerp and probably wrong way to use Time.deltaTime but it should work
		crosshair.position = cam.WorldToScreenPoint(aimPoint.position); //UI crosshair placed on physical aim point position

		if(forceGunIntoHand)
		PutGunInHand();
	}
	void PutGunInHand() //This is done to prevent inherited scale from animation. Easier than resetting global scale.
	{
		gunMesh.transform.position = handBone.position;
		if(forceGunAim)
		{
			gunMesh.transform.LookAt(aimPoint.position, transform.up); //Point gun towards crosshair
		}
		else
		{
			gunMesh.transform.rotation = handBone.rotation; //Plainly attach gun to hand. This works if the LookAt or Animation Riggin solutions fail
		}
	}
}
