using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class GetGrabbed : MonoBehaviour {
    bool isBeingDragged = false;
    Hand draggingHand;
    SpringJoint sj;
	void Start () {
        isBeingDragged = false;
    }
	
	void Update () {
        if (isBeingDragged)
        {
            if (!draggingHand.controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
                Debug.Log(currentVelocity);
                DestroyImmediate(sj);
                GetComponent<Rigidbody>().AddForce(currentVelocity);
                isBeingDragged = false;
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Hand>())
        {
            if (other.GetComponent<Hand>().controller.GetPress(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                if(!isBeingDragged)
                {
                    isBeingDragged = true;
                    draggingHand = other.GetComponent<Hand>();
                    sj = gameObject.AddComponent<SpringJoint>();
                    sj.connectedBody = other.GetComponent<Rigidbody>();
                    sj.spring = 2000.0f;
                    sj.tolerance = 0.0f;
                    sj.autoConfigureConnectedAnchor = false;
                    sj.anchor = Vector3.zero;
                    sj.connectedAnchor = Vector3.zero;
                    sj.maxDistance = 0.001f;
                }
            }
        }
    }
}
