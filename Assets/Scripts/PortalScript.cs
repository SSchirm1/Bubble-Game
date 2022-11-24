using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider collided) 
    {
        if (ScoreScript.allCollected) 
        {
            SceneManager.LoadScene(2); // win scene
        }
    }
    
}
