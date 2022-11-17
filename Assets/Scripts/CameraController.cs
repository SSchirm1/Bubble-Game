using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraDistance = 10.0f;
    float xMove, zMove;
    float timer = 0;
    public float height = 6;

    // Use this for initialization
    void Start () {
    }

    void LateUpdate ()
    {
        xMove = Input.GetAxis("Horizontal");
        zMove = Input.GetAxis("Vertical");
        Debug.Log(xMove + " " + zMove);
        Vector3 pos = new Vector3(player.transform.position.x - xMove * cameraDistance, height, player.transform.position.z - zMove * cameraDistance);
        transform.position = pos;

        
             transform.LookAt (player.transform.position, Vector3.up);
        
       
     
       
    }
}