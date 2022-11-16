using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour {

    public GameObject player;
    public float cameraDistance = 10.0f;

    // Use this for initialization
    void Start () {
    }

    void LateUpdate ()
    {
        transform.position = player.transform.position - player.transform.forward * cameraDistance;
        Vector3 playerxz = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        transform.position = new Vector3 (transform.position.x , transform.position.y , transform.position.z) ;
        transform.LookAt (player.transform.position, Vector3.up);
        
     
       
    }
}