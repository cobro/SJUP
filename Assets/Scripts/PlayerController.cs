using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public float dashSpeed;
    private Vector2 input;

    public GameObject water;
    private Collider2D waterCollider;
    public Collider2D playerCollider;

    public Transform tf;


	void Start () {
        rb = this.GetComponent("Rigidbody2D") as Rigidbody2D;
        waterCollider = water.GetComponent("BoxCollider2D") as BoxCollider2D;
	}


    void FixedUpdate()
        {

        if (playerCollider.IsTouching(waterCollider) == true)
            {
            rb.gravityScale = 0f;    
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rb.AddForce(input * speed);

            if (Input.GetKeyDown("space") == true)
                {
                Dash();
                }
            }
        else
            {
            rb.gravityScale = 1f;
            }

        if (Input.GetAxis("Horizontal") <= 0)
            {
            tf.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        else
            {
            tf.eulerAngles = new Vector3(0f, 0f, 0f);
            }
	}

    public void Dash()
        {
        rb.AddForce(input * dashSpeed, ForceMode2D.Impulse);
        }
}
