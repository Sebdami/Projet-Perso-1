using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandInitializer : MonoBehaviour {

    Hand hand;
    // Use this for initialization
    void Start()
    {
        hand = GetComponent<Hand>();
        switch (hand.startingHandType)
        {
            case Hand.HandType.Left:
                hand.controller = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost));
                break;
            case Hand.HandType.Right:
                hand.controller = SteamVR_Controller.Input(SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost));
                break;
        }
    }
}
