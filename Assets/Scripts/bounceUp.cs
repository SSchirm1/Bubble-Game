using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounceUp : MonoBehaviour
{

    public float force = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("player bounced");
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * force);
        }
    }
}
