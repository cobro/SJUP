using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

    public GameObject mine;
    public Vector3 minSpawnV3;
    public Vector3 maxSpawnV3;
    public float spawnTime = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        InvokeRepeating("SpawnMine", spawnTime, spawnTime);
	}

    public void SpawnMine()
    {
        Instantiate(mine);
    }
}
