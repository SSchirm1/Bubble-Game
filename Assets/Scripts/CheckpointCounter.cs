using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCounter : MonoBehaviour
{
    public bool activated;

    void Start()
    {
        activated = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!activated)
            {
                activated = true;
                ScoreScript.checkpointValue += 1;
            }
        }
    }

}
