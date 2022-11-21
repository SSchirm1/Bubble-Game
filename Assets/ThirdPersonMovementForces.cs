using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementForces : MonoBehaviour
{

 [Header("Player model")]
    public Transform cam;

    public GameObject playerObject;
    public Material ballMat;
    public Material bubbleMat;

    public float turnSmoothTime = 0f;
    float turnSmoothVelocity;

 [Header("Movement")]
    public float speed;

    public float groundDrag;

    public float jumpForce;
    public float airMultiplier;
    bool readyToJump;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    bool canJump;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        readyToJump = true;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        // temporary
        playerObject.GetComponent<MeshRenderer>().material = ballMat;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

        // handle drag
        if (grounded) {
            rb.drag = groundDrag;
            canJump = true;
        } else {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && canJump)
        {

            Jump();

        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 moveDelta = (moveDir.normalized * speed);
            
            rb.AddForce(moveDelta * 10f, ForceMode.Force);
        }
            

    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        Vector3 jump = new Vector3(0, jumpForce, 0);
        
        rb.AddForce(jump, ForceMode.Impulse);
        canJump = false;
    }
 
}