using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updrift : MonoBehaviour
{


    private Rigidbody rb;
    public float force = 30f;
    public float timePassed = 0;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (timePassed > 3) {
        CancelInvoke();
      }

    }

     void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Pushup(other);
        }
    }

    void Pushup(Collider player) {
        rb = player.GetComponent<Rigidbody>();
        Debug.Log("Entered zone");
        InvokeRepeating("applyForce",0,0.02f);
       
       
        
    }


    void applyForce() {
        rb.AddForce(new Vector3(0,force,0), ForceMode.Force);
        timePassed += 0.02f;
        if (timePassed > 3) {
            CancelInvoke();
            timePassed = 0;
        }

    }
}
