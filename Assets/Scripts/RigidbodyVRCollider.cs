using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RigidbodyVRCollider : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    void OnTriggerEnter(Collider col)
    {
        VelocityEstimator ve = transform.parent.GetComponentInParent<VelocityEstimator>();
        if(ve != null)
        {
            Debug.Log("hit");
            Rigidbody rb2 = col.GetComponent<Rigidbody>();
            rb2.velocity = Vector3.Cross(rb2.velocity, ve.GetVelocityEstimate());
        }
        else
        {
            Debug.Log(col.name + " Doesn't have a Velocity Estimator");
        }
    }
}
