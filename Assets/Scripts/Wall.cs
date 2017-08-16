using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public delegate void DestroyEvent();
	public static event DestroyEvent OnDestroy;


	void Start () {
		
	}
	
	void Update () {
		if(Camera.main.WorldToScreenPoint(transform.position).y < 0){
			Destroy (gameObject);
			if (OnDestroy != null){
				OnDestroy ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Add One Point");
	}
}
