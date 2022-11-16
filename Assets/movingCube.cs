using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCube : MonoBehaviour
{

    public GameObject gb;
    public Vector3 scaleChange;
    public float scaleMax;
    private float startScale;
    private bool growState = true;
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = gb.transform;
        float startScale = transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (growState) {
            transform.localScale += scaleChange;
            
            if (transform.localScale.y >= scaleMax ) {
                growState = false;
            }
        }
        else {
            transform.localScale -= scaleChange;
            if (transform.localScale.y < 0.1) {
                growState = true;
            }
        }
        
    }
}
