using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
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
            Debug.Log("player died");
            col.gameObject.transform.position = col.gameObject.GetComponentInChildren<ThirdPersonMovementForces>().checkpoint;
        }
    }
}
