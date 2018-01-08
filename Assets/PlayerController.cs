using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform hand1;
    [SerializeField]
    Transform hand2;

    [SerializeField]
    float force = 8.0f;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hand1.GetComponent<Hand>().controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            rb.AddForce(hand1.forward * force);
        }
        if (hand2.GetComponent<Hand>().controller.GetPress(Valve.VR.EVRButtonId.k_EButton_Grip))
        {
            rb.AddForce(hand2.forward * force);
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 10.0f);
        //Vector3 rot = transform.eulerAngles;

        //rot.y += hand1.GetComponent<Hand>().controller.GetTouch(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad)? 0.5f :0.0f;
        //transform.eulerAngles = rot;
    }
}