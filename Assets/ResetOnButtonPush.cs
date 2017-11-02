using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnButtonPush : MonoBehaviour {
    Vector3 startPos;
    Rigidbody rb;
    [SerializeField]
    float force = 3.0f;
	// Use this for initialization
	void Start () {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if(SteamVR_Controller.Input(1).GetHairTriggerDown())
        {
            Reset();
        }
	}

    private void Reset()
    {
        transform.position = startPos;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(-0.3f, 0.3f), 0, Random.Range(-1.3f, -0.7f)) *(force+Random.Range(-0.1f, 0.2f)), ForceMode.Impulse);
    }
}
