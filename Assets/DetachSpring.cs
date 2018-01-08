using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachSpring : MonoBehaviour {
    public ThrowableSpawner spawner;
	public void Detach()
    {
        if(GetComponent<SpringJoint>())
            DestroyImmediate(GetComponent<SpringJoint>());
        if(transform.childCount > 1)
            DestroyImmediate(transform.GetChild(1).gameObject);
        if(spawner)
        {
            spawner.Detached();
            spawner = null;
        }

    }
}
