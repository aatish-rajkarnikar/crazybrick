using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public delegate void DestroyEvent();
	public static event DestroyEvent OnDestroy;
	private ScoreManager scoreManager;

	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			scoreManager = gameControllerObject.GetComponent <ScoreManager>();
		}
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
		scoreManager.addScore ();
	}
}
