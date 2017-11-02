using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class SliderVRValueChanger : MonoBehaviour {

	void OnTriggerStay(Collider col)
    {
        if(col.GetComponent<Hand>())
        {
            if(col.GetComponent<Hand>().controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                //Transform tr = col.transform.position * transform.worldToLocalMatrix;
            }
        }
    }
}
