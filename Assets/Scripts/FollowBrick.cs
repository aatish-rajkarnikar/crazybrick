using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBrick : MonoBehaviour {

	public GameObject gameObject;

	void LateUpdate () 
	{
		if (gameObject.transform.position.y > transform.position.y) {
			transform.position = new Vector3(transform.position.x, gameObject.transform.position.y, transform.position.z);
		}
	}
}
