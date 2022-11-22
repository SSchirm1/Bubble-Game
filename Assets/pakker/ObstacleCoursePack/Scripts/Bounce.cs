using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
	public float force = 10f; //Force 10000f
	public float stunTime = 0.5f;
	private Vector3 hitDir;

	void OnCollisionEnter(Collision collision)
	{
        Debug.Log("collided");

        foreach (ContactPoint contact in collision.contacts)
		{
			Debug.DrawRay(contact.point, contact.normal, Color.white);
			if (collision.gameObject.tag == "Player")
			{
                //Debug.Log("bounced");
                hitDir = contact.normal;
                Debug.Log("player hit");
                collision.gameObject.GetComponentInChildren<Rigidbody>().AddForce(-hitDir * force);
                //collision.gameObject.GetComponent<ThirdPersonMovementForces>().HitPlayer(-hitDir * force, stunTime);
                return;
			}
		}
		/*if (collision.relativeVelocity.magnitude > 2)
		{
			if (collision.gameObject.tag == "Player")
			{
				//Debug.Log("Hit");
				collision.gameObject.GetComponent<CharacterControls>().HitPlayer(-hitDir*force, stunTime);
			}
			//audioSource.Play();
		}*/
	}
}
