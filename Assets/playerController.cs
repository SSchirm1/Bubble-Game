using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject gb;

    private float xInput;
    private float zInput;
    public static float keydir = 1;
    public float speed = 25f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    

    void FixedUpdate() {
        //Movement
       
        ProcessInputs();
        Move();
    }

    private void ProcessInputs() {
        xInput = Input.GetAxis("Horizontal") * keydir;
        zInput = Input.GetAxis("Vertical") * keydir;
    }

    private void Move() {

   
        rb.AddForce(new Vector3(xInput*speed, 0f, zInput*speed));
       
    }
}
