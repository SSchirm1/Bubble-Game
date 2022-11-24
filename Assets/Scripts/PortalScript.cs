using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public Material portalMat;

    private void OnTriggerEnter(Collider collided) 
    {
        if (ScoreScript.allCollected) 
        {
            SceneManager.LoadScene(2); // win scene
        }
    }

    private void Update()
    {
        if (ScoreScript.allCollected) {
            gameObject.GetComponent<MeshRenderer>().material = portalMat;
        }
    }
    
}
