using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter(Collider collided) 
        {
            if (ScoreScript.allCollected) 
            {
                SceneManager.LoadScene(2); // win scene
            }
        }
    }
}
