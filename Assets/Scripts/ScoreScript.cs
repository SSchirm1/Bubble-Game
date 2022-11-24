using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreScript : MonoBehaviour


{
    // Start is called before the first frame update

    public static int scoreValue = 0;
    TextMeshProUGUI score;
    float count;
    public GameObject[] getCount;
    void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
        getCount = GameObject.FindGameObjectsWithTag("collectible");
        count = getCount.Length;
    }

    // Update is called once per frame
    void Update()
    {
        score.SetText("Objekter samlet: {0}/{1}", scoreValue, count);
    }
}
