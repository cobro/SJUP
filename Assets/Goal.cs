using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public GameObject ball;
    public CircleCollider2D ballCollider;
    public Collider2D goalCollider;
    public GameObject uiElement;
    public UnityEngine.UI.Text uiText;
    public float score;

	void Start () {
        ballCollider = ball.GetComponent("CircleCollider2D") as CircleCollider2D;
        uiText = uiElement.GetComponent("Text") as UnityEngine.UI.Text;
	}

    void Update () {
        uiText.text = score.ToString();
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
        score++;
        ball.transform.position = new Vector3(0.5f, 5.4f);
        }
}
