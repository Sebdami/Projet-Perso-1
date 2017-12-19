using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallValuesChanger : MonoBehaviour {
    ResetOnButtonPush robp;
    Vector3 startSize;
    float startForce;
    AudioSource audioSource;
    [SerializeField]
    AudioClip ballOnTable;
    [SerializeField]
    AudioClip ballOnPaddle;
	
	void Start () {
        robp = GetComponent<ResetOnButtonPush>();
        startSize = transform.localScale;
        startForce = robp.forceToAdd;
        audioSource = GetComponent<AudioSource>();

    }
	
	public void ChangeSize(float value)
    {
        float multiplier = Mathf.Lerp(0.2f, 2.0f, value);
        transform.localScale = startSize * multiplier;
    }

    public void ChangeSpeed(float value)
    {
        robp.forceToAdd = Mathf.Lerp(-2.0f, 4.0f, value);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.GetComponent<FixedJoint>() && collision.collider.GetComponent<FixedJoint>().connectedBody.GetComponent<Valve.VR.InteractionSystem.Hand>())
        {
            audioSource.clip = ballOnPaddle;
            audioSource.volume = 0.7f + Mathf.Clamp(collision.relativeVelocity.magnitude / 10.0f, 0.0f, 1.0f);
        }  
        else
        {
            audioSource.clip = ballOnTable;
            audioSource.volume = 0.2f + Mathf.Clamp(collision.relativeVelocity.magnitude / 10.0f, 0.0f, 1.0f);
        }
            
        audioSource.Play();
    }
}
