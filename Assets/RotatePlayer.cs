 using UnityEngine;
 using System.Collections;
 
 [RequireComponent(typeof(CharacterController))]
 public class RotatePlayer : MonoBehaviour
 {
     public float Speed = 3.0F;
     public float RotateSpeed = 1F;
     void Update()
     {
         CharacterController controller = GetComponent<CharacterController>();
         if (transform != null)
         {
             transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
             var forward = transform.TransformDirection(Vector3.forward);
             float curSpeed = Speed * Input.GetAxis("Vertical");
        
         }
     }
 }