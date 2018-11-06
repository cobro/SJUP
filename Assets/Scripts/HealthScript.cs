using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    public int playerHealth = 3;
    public GameObject goal;
    public GameObject health;
	
	void Start () {
		
	}
	
	
	void Update () {
        if (playerHealth == 0)
        {
            goal.SendMessage("GameOver");
        }
	}

    public void Explosion()
    {
        playerHealth--;
        health.SendMessage("LoseHealth");
    }
}
