using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    public float multiplier = 1.05f;
    public GameObject pickupEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Pickup(other);
        }
    }

    void Pickup(Collider player) {
        Debug.Log("Picked up");
        Instantiate(pickupEffect, transform.position, transform.rotation);
        Instantiate(player, transform.position + new Vector3(0,0.05f, 0), transform.rotation);
        player.transform.localScale *= multiplier; 
        player.transform.position += new Vector3(0,0.1f,0);
        Destroy(gameObject);
        Destroy(pickupEffect, 1);


    }
}
