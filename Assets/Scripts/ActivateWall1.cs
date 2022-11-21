using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWall1 : MonoBehaviour
{
    public GameObject activatedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("collided, activating..");
            activatedObject.GetComponent<WallMovable>().enabled = true;
        }
    }
}
