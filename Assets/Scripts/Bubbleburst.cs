using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbleburst : MonoBehaviour
{

    public GameObject gb;
    public Material ballMat;
    public Material bubbleMat;
    Rigidbody rb;
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
        rb.useGravity = false;
        rb.AddForce(0, 50f, 0);
        gb.GetComponent<MeshRenderer>().material = bubbleMat;
        state = 0;
       }
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("crashed");
        rb.useGravity = true;
        gb.GetComponent<MeshRenderer>().material = ballMat;
        state = 1;

    
       
    }


}
