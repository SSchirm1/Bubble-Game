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

    private AudioSource soapAudio;

    public float turnSmoothTime = 0f;
    float turnSmoothVelocity;

 [Header("Movement")]
    public float speed;
    private float originalSpeed;

   

    public float groundDrag;
    public float bubbleDrag;

    public float jumpForce;
    public float airMultiplier;
    bool readyToJump;

    public Vector3 checkpoint;
    AudioSource audio_data;

    public float airUp;
    public float airDown;


    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;


    float horizontalInput;
    float verticalInput;
    public float upDrift = 3;

    Vector3 moveDirection;

    Rigidbody rb;

    bool canJump;
    public float bubbleForce = .3f;
    enum State {
        ball,
        soap,
        bubble,
    }

    State state;

    private bool jumpCharge;
    private bool floatUpCharge;
    private bool floatDownCharge;

    public static bool isSoaped = false;

    public AudioSource jumpAudio;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        originalSpeed = speed;

        jumpAudio = GetComponent<AudioSource>();
       
        
        state = State.ball;
        becomeBall();

        Time.timeScale = 1.5f;
    }

    private void OnCollisionEnter(Collision collision)
    {

        // check if collided with soap, change to soaped if
        if(state == State.bubble) {
            state = State.ball;
            becomeBall();    
        }

        if (collision.gameObject.tag == "Soap" && state != State.soap) {
            state = State.soap;
            isSoaped = true;
            

        }
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);
        
        MyInput();
        SpeedControl();
        
        // handle drag
        if (grounded) {
            canJump = true;
            rb.drag = groundDrag;
            
        } else if (state == State.bubble) {
            rb.drag = bubbleDrag;
        } else {
            rb.drag = 0;
        }

        

    }

    private void FixedUpdate()
    {
        MovePlayer();
        
        if (jumpCharge)
            Jump();
            jumpCharge = false;
        
        if (floatUpCharge)
            FloatUp();
            floatUpCharge = false;

        if (floatDownCharge)
            FloatDown();
            floatDownCharge = false;


        if (state == State.bubble) {
             rb.AddForce(new Vector3(0, -1.0f, 0)*rb.mass*bubbleForce);  
        }
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // when to jump
        if(Input.GetKey(jumpKey) && canJump && state != State.bubble)
        {
            jumpCharge = true;
        }

        if(Input.GetKey(jumpKey) && state == State.bubble) {
            floatUpCharge = true;
        }

        if(Input.GetKey(KeyCode.LeftShift) && state == State.bubble) {
            floatDownCharge = true;
        }

        // turn to bubble
        if(Input.GetKey(KeyCode.E) && state == State.soap) {
            state = State.bubble;
            isSoaped = false;
            becomeBubble();
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

        jumpAudio.Play();

        rb.AddForce(jump, ForceMode.Impulse);
        canJump = false;
        
    }

    private void becomeBall() {
        if (state == State.ball) {
            playerObject.GetComponent<MeshRenderer>().material = ballMat;
            rb.useGravity = true;
            speed = originalSpeed;
        }

    }

    private void becomeBubble() {
        if (state == State.bubble) {
            playerObject.GetComponent<MeshRenderer>().material = bubbleMat;
            rb.useGravity = false;
            speed = speed / 2;
            rb.AddForce(Vector3.up * upDrift, ForceMode.Impulse);

        }
    }

    private void FloatUp() {
        Vector3 FloatUp = new Vector3(0, airUp, 0);

        rb.AddForce(FloatUp, ForceMode.Impulse);
    }

    private void FloatDown() {
        Vector3 FloatDown = new Vector3(0, -airDown, 0);

        rb.AddForce(FloatDown, ForceMode.Impulse);
    }
 
}