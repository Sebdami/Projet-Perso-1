using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallValuesChanger : MonoBehaviour {
    [SerializeField]
    GameObject Ball;
    Vector3 startPosition;
    float startBallStartForce;
	void Start () {
        startPosition = transform.position;
        startBallStartForce = Ball.GetComponent<ResetOnButtonPush>().startForce;
	}
	

	public void ChangeWallDistance(float value)
    {
        transform.position = startPosition + (Vector3.forward * Mathf.Lerp(-2.0f, 5.0f, value));
        Ball.GetComponent<ResetOnButtonPush>().startForce = startBallStartForce * Mathf.Lerp(0.5f, 2.0f, value);
    }
}
