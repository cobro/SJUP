using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    public GameObject goal;
    


	void Start () {
		
	}
	
	
	void Update () {
		
	}

    public void PlayerDeath()
    {
        goal.SendMessage("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
