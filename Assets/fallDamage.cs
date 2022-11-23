using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDamage : MonoBehaviour
{
    // Start is called before the first frame update
    float height;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        height = transform.position.y;
        if (height < -100) {
            
        }
    }
}
