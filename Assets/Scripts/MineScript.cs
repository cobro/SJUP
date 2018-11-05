using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScript : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private Collider2D p1Collider;
    private Collider2D p2Collider;
    private Collider2D mineCollider;

	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        p1Collider = player1.GetComponent("BoxCollider2D") as BoxCollider2D;
        p2Collider = player2.GetComponent("BoxCollider2D") as BoxCollider2D;
        mineCollider = gameObject.GetComponent("CircleCollider2D") as CircleCollider2D;
    }
	
	// Update is called once per frame
	void Update () {
        if (mineCollider.IsTouching(p1Collider) == true)
        {
            player1.SendMessage("Explosion");
            Destroy(this);
        }

        if (mineCollider.IsTouching(p2Collider) == true)
        {
            player2.SendMessage("Explosion");
            Destroy(this);
        }
    }
}
