using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos : MonoBehaviour
{
	public Vector3 checkPoint;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
            Debug.Log("checkpoint reached");
            col.GetComponentInChildren<ThirdPersonMovementForces>().checkpoint = transform.position;
           // col.gameObject.GetComponent<CharacterControls>().checkPoint = checkPoint.position;
		}
	}
}
