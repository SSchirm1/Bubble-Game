using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWaits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float count = 0;
    float time = 0;

    void OnTriggerEnter(Collider other) {
        Debug.Log("freezing");
        if (other.gameObject.tag == "Player" && count < 1) {
            time += Time.deltaTime;
            while (time < 2) {
                other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
        }
     }
}
