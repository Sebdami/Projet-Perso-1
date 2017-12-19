using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class TestCollisionVibration : MonoBehaviour {
    Hand hand;

	void Start () {
        hand = GetComponent<FixedJoint>().connectedBody.GetComponent<Hand>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        hand.controller.TriggerHapticPulse((ushort)Mathf.Clamp((collision.relativeVelocity.magnitude * 1000f), 0f, 3999f));
    }
}
