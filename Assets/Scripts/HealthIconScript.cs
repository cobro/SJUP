using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIconScript : MonoBehaviour {

    public GameObject health1;
    public GameObject health2;
    public GameObject health3;

    List<GameObject> health = new List<GameObject>();
    private int index = 0;

	void Start () {
        health.Add(health1);
        health.Add(health2);
        health.Add(health3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoseHealth()
    {
        health[index].SetActive(false);
        index++;
    }
}
