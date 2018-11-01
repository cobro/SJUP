using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public GameObject ball;
    public CircleCollider2D ballCollider;
    public Collider2D goalCollider;
    public GameObject p1UIElement;
    public UnityEngine.UI.Text p1UIText;
    public GameObject p2UIElement;
    public UnityEngine.UI.Text p2UIText;
    public float p1Score;
    public float p2Score;


	void Start () {
        ballCollider = ball.GetComponent("CircleCollider2D") as CircleCollider2D;
        p1UIText = p1UIElement.GetComponent("Text") as UnityEngine.UI.Text;
        p2UIText = p2UIElement.GetComponent("Text") as UnityEngine.UI.Text;
        }

    void Update () {
        p1UIText.text = p1Score.ToString();
        p2UIText.text = p2Score.ToString();
        }

    private void OnTriggerEnter2D(Collider2D col)
        {
        if (col.name == ball.name)
            {
            GoalEvent();
            }
        }

    public void GoalEvent ()
        {
        if (WaterPhysics.lastTouch.tag == "Player1")
            {
            p1Score++;
            Debug.Log("Player 1 Scored");
            }
        else if (WaterPhysics.lastTouch.tag == "Player2")
            {
            Debug.Log("Player 2 Scored");
            p2Score++;
            }

        ball.transform.position = new Vector3(-4f, 5.4f);
        }
}
