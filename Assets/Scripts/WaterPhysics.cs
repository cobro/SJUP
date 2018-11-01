using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour {

    public GameObject water;
    public Collider2D ballCollider;
    public BoxCollider2D waterCollider;
    public Rigidbody2D ballRB;
    public float waterDrag;

    public static GameObject lastTouch;


	
	void Start () {
        waterCollider = water.GetComponent<BoxCollider2D>();
        ballRB = this.GetComponent<Rigidbody2D>();
	}
	
	
	void Update () {
       if (ballCollider.IsTouching(waterCollider) == true)
            {
            ballRB.gravityScale = -1f;
            ballRB.drag = waterDrag;
            }
        else
            {
            ballRB.gravityScale = 1f;
            ballRB.drag = 0f;
            }
        }
    private void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.gameObject.tag == "Player1")
            {
            lastTouch = collision.gameObject;
            Debug.Log(lastTouch.name + " touched");
            }
        else if (collision.gameObject.tag == "Player2")
            {
            lastTouch = collision.gameObject;
            Debug.Log(lastTouch.name + " touched");
            }
        }
    }
