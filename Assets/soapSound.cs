using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soapSound : MonoBehaviour
{

    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {

        Transform child = transform.GetChild(0);
        audio = child.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Soap") {
            audio.Play();
        }
    }
}
