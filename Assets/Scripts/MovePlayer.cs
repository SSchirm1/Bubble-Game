using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float horizontalMovement;
    private float verticalMovement;

    // A field editable from inside Unity with a default value of 5
    public float speed = 20.0f;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // This will detect forward and backward movement
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        
       
        // This will detect sideways movement
        verticalMovement = Input.GetAxisRaw("Vertical");

        // Calculate the direction to move the player
        Vector3 movementDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    
        // Move the player
        rb.AddForce(movementDirection * speed, ForceMode.Force);
    }
}