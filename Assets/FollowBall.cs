using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{

    private Vector3 camPos;
    public Transform ball;
    public float offsetZ = 5;
    public float offsetY = 2;

    // Start is called before the first frame update
    void Start()
    {
        camPos = transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballPos = ball.transform.position;

        transform.position = ballPos + Vector3.back * offsetZ + Vector3.up * offsetY;
        transform.LookAt(ballPos);

    }
}
