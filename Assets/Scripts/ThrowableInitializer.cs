using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableInitializer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpringJoint>().connectedBody = transform.parent.GetComponent<Rigidbody>();
        transform.GetChild(1).GetComponent<ConnectLines>().tr1 = transform.parent;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
