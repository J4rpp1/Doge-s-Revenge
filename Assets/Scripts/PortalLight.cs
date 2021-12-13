using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLight : MonoBehaviour, IHeatable
{
    MeshRenderer rend;
	[SerializeField] Material hotMaterial;
	[SerializeField] GameObject endPlatform;
	EndPlatform endPlatformScript;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
		endPlatformScript = endPlatform.GetComponent<EndPlatform>();
    }

    // Update is called once per frame
    public void Heat()
    {
        rend.material = hotMaterial;
		endPlatformScript.Overcharge();
    }
	public void PreHeat()
    {
        rend.material = hotMaterial;
		endPlatformScript.Overcharge();
    }
}
