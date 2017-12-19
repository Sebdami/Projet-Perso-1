using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetOnButtonPush : MonoBehaviour {
    [SerializeField]
    Transform startPos;
    Rigidbody rb;
    public float startForce = 3.0f;
    public float forceToAdd = 0.0f;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
		if(SteamVR_Controller.Input(1).GetHairTriggerDown() || SteamVR_Controller.Input(0).GetHairTriggerDown() || Input.GetKeyDown(KeyCode.Space))
        {
            Reset();
        }
	}

    private void Reset()
    {
        transform.position = startPos.position;
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector3(Random.Range(-0.15f, 0.15f), 0, Random.Range(-1.3f, -0.7f)) *(startForce + forceToAdd + Random.Range(-0.1f, 0.2f)), ForceMode.Impulse);
    }
}
