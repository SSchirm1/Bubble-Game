using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevate : MonoBehaviour
{

    public float speed;
    public bool movingUp = true;

    public float height = 10;
    // Start is called before the first frame update
    public Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {

        if (movingUp) {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, height, 0), speed * Time.deltaTime);
            if(transform.position.y == startPos.y + height) {
                movingUp = false;
            }
        }
    }

    

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            moveUp();
        }
    }

    void moveUp() {
        
    }
}
