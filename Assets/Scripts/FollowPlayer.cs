using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    private Transform camTransform;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Boble").transform;
        camTransform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(player.position);
        camTransform.rotation = new Quaternion(0,player.rotation.y, 0, 0);
        camTransform.position = player.position - Vector3.back;
    }
}
