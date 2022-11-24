using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoapScript : MonoBehaviour
{

    public GameObject text;
    
    // Update is called once per frame
    void Update()
    {
        if (ThirdPersonMovementForces.isSoaped)
        {
            text.SetActive(true);
        } else {
            text.SetActive(false);
        }
    }
}
