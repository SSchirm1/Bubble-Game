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
    public float ballWeight = 10;
    public float bubbleWeight = 1;
    public float jumpforce = 100;
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
       if(Input.GetButtonDown("Jump") ) {
            Debug.Log("jumped");
            rb.AddForce(0, jumpforce, 0);
       
  
       }

       if (Input.GetKeyDown(KeyCode.Z) ) {
        if (state == 0) {
            rb.AddForce(0, force, 0);
        }
         
        gb.GetComponent<MeshRenderer>().material = bubbleMat;
        state = 0;
        rb.mass = bubbleWeight;

        rb.drag = bubbleDrag;

        timePassed = 0;
         InvokeRepeating("applyForce",0,0.02f);
  
       }
    }

    void OnCollisionEnter(Collision collision) {
      
        rb.useGravity = true;
        gb.GetComponent<MeshRenderer>().material = ballMat;
        rb.mass = ballWeight;
        state = 1;
        rb.drag = ballDrag;

    
       
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
