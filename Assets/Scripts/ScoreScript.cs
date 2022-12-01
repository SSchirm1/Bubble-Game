using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreScript : MonoBehaviour


{
    // Start is called before the first frame update

    public static int scoreValue;
    public static int checkpointValue;
    public static bool allCollected = false;
    TextMeshProUGUI score;
    public TextMeshProUGUI checkpoint;
    float scoreCount;
    float checkpointCount;
    public GameObject[] getCount;
    public GameObject[] getCheckpointCount;

    void Start()
    {
        ScoreScript.scoreValue = 0;
        ScoreScript.checkpointValue = 0;
        score = GetComponent<TextMeshProUGUI>();
        getCount = GameObject.FindGameObjectsWithTag("collectible");
        scoreCount = getCount.Length;
        getCheckpointCount = GameObject.FindGameObjectsWithTag("Soap");
        checkpointCount = getCheckpointCount.Length;
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText(": {0}/{1}", scoreValue, scoreCount);
        checkpoint.SetText(": {0}/{1}", checkpointValue, checkpointCount);
        if (checkpointValue == checkpointCount) 
        {
            allCollected = true;
        }
    }
}
