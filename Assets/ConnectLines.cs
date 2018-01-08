using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectLines : MonoBehaviour {
    [SerializeField]
    LineRenderer lr;
    public Transform tr1;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(0, tr1.position);
        lr.SetPosition(1, transform.position);
    }
}
