using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbleburst : MonoBehaviour
{

    public GameObject gb;
    public float force = 30f;
    private float timePassed;
    public Material ballMat;
    public Material bubbleMat;
    Rigidbody rb;
    public float bubbleDrag = 30;
    public float ballDrag = 8;
    int state;
    // Start is called before the first frame update
    void Start()
    {
        rb = gb.GetComponent<Rigidbody>();
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetButtonDown("Jump") && state == 1) {
        
        rb.AddForce(0, 50f, 0);
        gb.GetComponent<MeshRenderer>().material = bubbleMat;
        state = 0;

        rb.drag = bubbleDrag;

        timePassed = 0;
         InvokeRepeating("applyForce",0,0.02f);
        
        
       }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("crashed");
        rb.useGravity = true;
        gb.GetComponent<MeshRenderer>().material = ballMat;
        state = 1;
        rb.drag = ballDrag;

    
       
    }


      void applyForce() {
        Debug.Log("force applied");
        rb.AddForce(new Vector3(0,force,0), ForceMode.Force);
        timePassed += 0.02f;
        if (timePassed > 3) {
            CancelInvoke();
            timePassed = 0;
        }
      }


}
