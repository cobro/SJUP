using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraController : MonoBehaviour {

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private GameObject player4;
    private Vector3 player1Pos;
    private Vector3 player2Pos;
    private Vector3 player3Pos;
    private Vector3 player4Pos;

    public GameObject ball;
    private Vector3 ballPos;

    //Player to Player and Player to Ball distances
    private float p1p2;
    private float p1p3;
    private float p1p4;
    private float p1b;
    private float p2p3;
    private float p2p4;
    private float p2b;
    private float p3p4;
    private float p3b;
    private float p4b;

    //public List<float> distances = new List<float>();
    public List<DistancePairing> distances = new List<DistancePairing>();
    private int count;

    private Vector3 camPos;
    private float cameraX;
    private float cameraY;
    private float largestDistance;
    private Vector3 middlePos;
    public float camSpeed = 2f;

    public Camera cam;
    private GameObject zoomTarget1;
    private GameObject zoomTarget2;
    private float currentZoom;
    public float zoomMod = 1f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float zoomMath;
    private float zoomLevel = 5f;

	void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player3 = GameObject.FindGameObjectWithTag("Player3");
        player4 = GameObject.FindGameObjectWithTag("Player4");

        distances.Add(new DistancePairing(p1p2, player1, player2));
        distances.Add(new DistancePairing(p1p3, player1, player3));
        distances.Add(new DistancePairing(p1p4, player1, player4));
        distances.Add(new DistancePairing(p1b, player1, ball));
        distances.Add(new DistancePairing(p2p3, player2, player3));
        distances.Add(new DistancePairing(p2p4, player2, player4));
        distances.Add(new DistancePairing(p2b, player2, ball));
        distances.Add(new DistancePairing(p3p4, player3, player4));
        distances.Add(new DistancePairing(p3b, player3, ball));
        distances.Add(new DistancePairing(p4b, player4, ball));

        }

    void LateUpdate() {
        player1Pos = player1.transform.position;
        player2Pos = player2.transform.position;
        player3Pos = player3.transform.position;
        player4Pos = player4.transform.position;
        ballPos = ball.transform.position;

        p1p2 = Vector3.Distance(player1Pos, player2Pos);
        p1p3 = Vector3.Distance(player1Pos, player3Pos);
        p1p4 = Vector3.Distance(player1Pos, player4Pos);
        p1b = Vector3.Distance(player1Pos, ballPos);
        p2p3 = Vector3.Distance(player2Pos, player3Pos);
        p2p4 = Vector3.Distance(player2Pos, player4Pos);
        p2b = Vector3.Distance(player2Pos, ballPos);
        p3p4 = Vector3.Distance(player3Pos, player4Pos);
        p3b = Vector3.Distance(player3Pos, ballPos);
        p4b = Vector3.Distance(player4Pos, ballPos);

        changeAttribute(player1, player2, p1p2);
        changeAttribute(player1, player3, p1p3);
        changeAttribute(player1, player4, p1p4);
        changeAttribute(player1, ball, p1b);
        changeAttribute(player2, player3, p2p3);
        changeAttribute(player2, player4, p2p4);
        changeAttribute(player2, ball, p2b);
        changeAttribute(player3, player4, p3p4);
        changeAttribute(player3, ball, p3b);
        changeAttribute(player4, ball, p4b);

        distances.Sort();
        count = distances.Count;

        largestDistance = distances[9].distance;
        zoomTarget1 = distances[9].target1;
        zoomTarget2 = distances[9].target2;

        middlePos = Vector3.Lerp(zoomTarget1.transform.position, zoomTarget2.transform.position, 0.5f);

        camPos = new Vector3(middlePos.x, middlePos.y, -10f);
        transform.position = Vector3.Lerp(transform.position, camPos, camSpeed * Time.deltaTime);

        currentZoom = cam.orthographicSize;
        zoomMath = (largestDistance / 30) * zoomMod;
        Mathf.Clamp(zoomMath, 0f, 1f);
        cam.orthographicSize = Mathf.Lerp(currentZoom, Mathf.Clamp(Mathf.Lerp(1f, 20f, zoomMath), minZoom, maxZoom), camSpeed * Time.deltaTime);
	}

    public void changeAttribute(GameObject assObj1, GameObject assObj2, float newDistance)
        {
        distances.Find(p => p.target1 == assObj1 & p.target2 == assObj2).distance = newDistance;
        }

    
}

public class DistancePairing : IComparable<DistancePairing>
    {
    public float distance;
    public GameObject target1;
    public GameObject target2;

    public DistancePairing(float newDistance, GameObject t1, GameObject t2)
        {
        distance = newDistance;
        target1 = t1;
        target2 = t2;
        }

    public int CompareTo(DistancePairing other)
        {
        if (other == null)
            {
            return 1;
            }
        else if (distance > other.distance)
            {
            return 1;
            }
        else if (distance == other.distance)
            {
            return 0;
            }
        else
            {
            return -1;
            }
        }
    }
