using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScale : MonoBehaviour {


private float hsliderval=1.0f;

// Use this for initialization
void Start () {

hsliderval = 1.0f;

}

// Update is called once per frame
void Update () {

gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f) * hsliderval;

}

void OnGUI()
{
hsliderval = GUI.HorizontalSlider(new Rect(0.0f, 0.0f, 100.0f,20.0f) , hsliderval,1.0f, 15.0f);
//gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * hsliderval, gameObject.transform.localScale.y * hsliderval, gameObject.transform.localScale.z * hsliderval);


}
}