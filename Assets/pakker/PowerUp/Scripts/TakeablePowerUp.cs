using UnityEngine;
using System.Collections;


public class TakeablePowerUp : MonoBehaviour {
	CustomizablePowerUp customPowerUp;
    private Rigidbody rb;
    public float lives = 1;
    void Start() {
		customPowerUp = (CustomizablePowerUp)transform.parent.gameObject.GetComponent<CustomizablePowerUp>();
		//this.audio.clip = customPowerUp.pickUpSound;
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.tag == "Player") {
            ScoreScript.scoreValue += 1;
            rb = collider.GetComponent<Rigidbody>();
			//rb.AddForce(0, 5000f, 0);
           

            PowerUpManager.Instance.Add(customPowerUp);
			if(customPowerUp.pickUpSound != null){
				AudioSource.PlayClipAtPoint(customPowerUp.pickUpSound, transform.position);
			}
			Destroy(transform.parent.gameObject);
		}
	}
}
