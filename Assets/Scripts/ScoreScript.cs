using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour


{
    // Start is called before the first frame update

    public static int scoreValue = 0;
    Text score;
    float count;
    public GameObject[] getCount;
    void Start()
    {
        score = GetComponent<Text>();
        getCount = GameObject.FindGameObjectsWithTag("collectible");
        count = getCount.Length;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Objekter samlet: " + scoreValue + "/" + count;
    }
}
