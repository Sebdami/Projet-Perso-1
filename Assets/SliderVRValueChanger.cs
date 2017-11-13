using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using UnityEngine.UI;

public class SliderVRValueChanger : MonoBehaviour {
    static GameObject SliderBeingDragged;
    Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.GetComponent<Hand>())
        {
            if(SliderBeingDragged == null || SliderBeingDragged == gameObject)
            {
                if (col.GetComponent<Hand>().controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
                {
                    Vector3 tr = transform.worldToLocalMatrix * col.transform.position;
                    Debug.Log("Grabbed");
                    Debug.Log(tr.x);
                    slider.value = Mathf.Clamp(tr.x / 95.0f + 1.0f, 0.0f, 1.0f);
                    if(SliderBeingDragged == null)
                    {
                        SliderBeingDragged = gameObject;
                    }
                }
                else
                {
                    SliderBeingDragged = null;
                }
            }
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Hand>())
        {
            if (SliderBeingDragged == gameObject)
            {
                SliderBeingDragged = null;
            }
        }
    }
}
