 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutOnImpact : MonoBehaviour {
    public Material capMaterial;
    bool acceptCutCollision = true;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Blade>())
        {
            Vector3 vel = collision.collider.transform.parent.parent.GetComponent<Valve.VR.InteractionSystem.VelocityEstimator>().GetVelocityEstimate();
            float velMagnitude = vel.magnitude;
            Debug.Log(velMagnitude);
            if (acceptCutCollision && velMagnitude > 2.5f)
            {

                //GameObject[] objs = Slicer.SliceInstantiate(gameObject, new Plane(transform.localToWorldMatrix * collision.collider.transform.parent.parent.localPosition, transform.worldToLocalMatrix * -collision.collider.transform.parent.parent.right));
                GameObject[] objs = BLINDED_AM_ME.MeshCut.Cut(gameObject, collision.collider.transform.parent.parent.position, collision.collider.transform.parent.parent.right, capMaterial);
                if (objs != null)
                {
                    foreach (GameObject go in objs)
                    {
                        if (go.GetComponent<MeshCollider>() != null)
                        {
                            go.GetComponent<MeshCollider>().sharedMesh = go.GetComponent<MeshFilter>().sharedMesh;

                        }
                        else
                        {
                            go.AddComponent<MeshCollider>();
                        }
                        go.GetComponent<MeshCollider>().inflateMesh = true;
                        go.GetComponent<MeshCollider>().convex = true;

                        if (!go.GetComponent<Rigidbody>())
                            go.AddComponent<Rigidbody>();
                        go.AddComponent<Valve.VR.InteractionSystem.Throwable>();
                        if (go.GetComponent<CutOnImpact>() == null)
                            go.AddComponent<CutOnImpact>().capMaterial = capMaterial;
                        if (go != gameObject)
                            StartCoroutine(go.GetComponent<CutOnImpact>().DeactivateCutForSeconds(0.5f));
                        else
                            StartCoroutine(DeactivateCutForSeconds(0.5f));
                    }
                }
                
            }
        }
        
        
    }

    public IEnumerator DeactivateCutForSeconds(float seconds)
    {
        acceptCutCollision = false;
        yield return new WaitForSeconds(seconds);
        acceptCutCollision = true;
    }
}
