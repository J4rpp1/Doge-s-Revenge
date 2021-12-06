using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunAim : MonoBehaviour
{
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
	Vector3 aimDesiredPosition;
	Vector2 crosshairDesiredPosition;
	void FixedUpdate()
	{
		RaycastHit hit;
		// Does the ray intersect any objects excluding the player layer
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxAimRange, rayMask))
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
			aimDesiredPosition = hit.point;
		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxAimRange, Color.yellow);
			aimDesiredPosition = transform.position + transform.TransformDirection(Vector3.forward) * maxAimRange;
		}
	}
	void Update()
	{
		//aimPoint.position = aimDesiredPosition;
		aimPoint.position = Vector3.Lerp(aimPoint.position, aimDesiredPosition, 50f * Time.deltaTime); //wrong way to use lerp and probably wrong way to use Time.deltaTime but it should work
		//crosshairDesiredPosition = new Vector2(aimPoint.position.x, aimPoint.position.y);
		crosshair.position = cam.WorldToScreenPoint(aimPoint.position);
	}
}
