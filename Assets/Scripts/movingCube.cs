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
    public float startHeight = 0;
    private float startYpos;
    // Start is called before the first frame update
    void Start()
    {
        Transform transform = gb.transform;
        float startScale = transform.localScale.y;
        float startYpos = startScale / 2;
        Debug.Log(startYpos);
    }

    // Update is called once per frame
    void Update()
    {
        if (growState) {
            transform.localScale += scaleChange;
            transform.position = new Vector3(transform.position.x,  startHeight + transform.localScale.y/2, transform.position.z) + new Vector3(0, startYpos, 0);
            if (transform.localScale.y >= scaleMax ) {
                growState = false;
            }
        }
        else {
            transform.localScale -= scaleChange;
            transform.position = new Vector3(transform.position.x, startHeight +  transform.localScale.y - transform.localScale.y / 2, transform.position.z) + new Vector3(0, startYpos, 0);
            if (transform.localScale.y <= 0) {
                growState = true;
            }
        }
        
    }
}
