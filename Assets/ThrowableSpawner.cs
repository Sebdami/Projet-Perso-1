using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableSpawner : MonoBehaviour {
    [SerializeField]
    GameObject throwablePrefab;

    // Time after which the next object will be spaned after we grab the current
    [SerializeField]
    float spawnTime = 2.0f;
    [SerializeField]
    bool needToSpawn = true;
    [SerializeField]
    bool continuousSpawning = false;
    float timer = 2.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(needToSpawn || continuousSpawning)
        {
            timer += Time.deltaTime;
            if (timer > spawnTime)
            {
                timer = 0.0f;
                needToSpawn = false;
                Instantiate(throwablePrefab, transform).GetComponent<DetachSpring>().spawner = this;
               
            }
        }
		
	}

    public void Detached()
    {
        needToSpawn = true;
    }
}
