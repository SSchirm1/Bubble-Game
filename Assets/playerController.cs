using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public Rigidbody rb;

    private float xInput;
    private float zInput;
    public float speed = 25f;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate() {
        //Movement
        Move();
    }

    private void ProcessInputs() {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move() {
        rb.AddForce(new Vector3(xInput*speed, 0f, zInput*speed));
    }
}
