using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanerWall : MonoBehaviour {

	public GameObject wall;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 4; i++) {
			move ();
			createWall ();
		}
	}
		
	void OnDisable()
	{
		Wall.OnDestroy -= OnWallDestroyed;
	}

	void OnEnable()
	{
		Wall.OnDestroy += OnWallDestroyed;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void move(){
		transform.position = new Vector3(Random.Range(-1.4f, 1.4f), transform.position.y + 4,0);
	}

	private void createWall(){
		Instantiate(wall, transform.position, Quaternion.identity);
	}

	void OnWallDestroyed(){
		move ();
		createWall ();
	}
}
