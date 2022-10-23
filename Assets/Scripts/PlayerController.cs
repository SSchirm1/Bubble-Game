using UnityEngine;
 
public class PlayerController : MonoBehaviour
{
    public float _speed = .2f;
    private Rigidbody rb;
    public float _rotationSpeed = 10;
    public float fallingSpeed = -0.5f;
 
    private Vector3 rotation;
    public Transform cam;
 
    public void Start() {
    
        rb = GetComponent<Rigidbody>();
        
    }

    public void Update()
    {

        this.rotation = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        this.transform.Rotate(this.rotation.x, 0, this.rotation.z);
        rb.AddForce(Input.GetAxisRaw("Vertical") * transform.forward * _speed, ForceMode.Impulse);
        rb.AddForce(Input.GetAxisRaw("Horizontal") * transform.right * _speed, ForceMode.Impulse);
        //Vector3 move = new Vector3(0, fallingSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        //move = this.transform.TransformDirection(move);
        //_controller.Move(move * _speed);

       cam.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
 