using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLight : MonoBehaviour, IHeatable
{
    MeshRenderer rend;
	[SerializeField] Material hotMaterial;
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    public void Heat()
    {
        rend.material = hotMaterial;
    }
}
