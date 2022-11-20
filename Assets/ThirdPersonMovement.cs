using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform cam;

    public GameObject playerObject;
    public Material ballMat;
    public Material bubbleMat;

    public float speed = 6f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    SphereCollider collider;

    /** different bubble State;
    /* 0 = bubble
    /* 1 = ball
    /* 2 = soaped **/
    State state;

    enum State : int
    {
        bubble = 0,
        ball = 1,
        soaped = 2
    }

    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Confined;
        SphereCollider collider = playerObject.GetComponent<SphereCollider>();

    }
    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //isGrounded =  Physics.CheckCapsule(collider.bounds.center,new Vector3(collider.bounds.center.x,collider.bounds.min.y-0.1f,collider.bounds.center.z),0.5f);
        //isGrounded = Physics.Raycast(transform.position, -Vector3.up, playerObject.GetComponent<SphereCollider>().bounds.extents.y + 0.1f);

        if (isGrounded && velocity.y < 0)
        {
          velocity.y = -2f;

          playerObject.GetComponent<MeshRenderer>().material = ballMat;
           gravity = -20f;
            speed = 10f;
          state = State.ball;
        }
        
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        // player movement
        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Vector3 moveDelta = (moveDir.normalized * speed * Time.deltaTime);
            
            // sphere rotation
            Vector3 rotationAxis = Vector3.Cross(moveDelta / 2, Vector3.up);
            playerObject.transform.RotateAround(transform.position, rotationAxis, -Mathf.Sin(moveDelta.magnitude*0.5f*2*Mathf.PI)*Mathf.Rad2Deg);
            
            controller.Move(moveDelta);
        }

        // jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
          velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // turn into bubble
        // TODO: add soaped state support
        if (Input.GetKeyDown(KeyCode.E /* && state == 2 */) ) 
        {
          playerObject.GetComponent<MeshRenderer>().material = bubbleMat;

            gravity = -0.3f;
            speed = 3f;
            state = State.bubble;
            velocity.y = Mathf.Sqrt(5* jumpHeight * -1f * gravity);

          // update physics here?

        }

        // gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

}

