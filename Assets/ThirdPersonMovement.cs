using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

   public CharacterController controller;
   public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    //Vector3 velocity;

    void Start()
    {
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Confined;
    }
    // Update is called once per frame
    void Update()
    {
        
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Horizontal, 0f, Vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // virker ikke
            //velocity.y += Physics.gravity.y * Time.deltaTime;
            //moveDir += velocity * Time.deltaTime;


            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }

}

