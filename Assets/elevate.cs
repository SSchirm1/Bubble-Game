using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevate : MonoBehaviour
{

    public float speed;
    public bool isAtBottom = true;
    
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
        
        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, height, 0), speed * Time.deltaTime);

    
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            float time =0;
            
}
    }
}
