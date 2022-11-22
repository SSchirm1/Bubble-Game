using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollBalls : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player") {
             Transform balls = GameObject.Find("ballobstacles").transform;
        foreach (Transform child in balls) {
            child.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
       
        }

    }
}
