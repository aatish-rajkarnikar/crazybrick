using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour {

	// Use this for initialization
	public Button startButton;

	void Start () {
		startButton.onClick.AddListener (StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame(){
		SceneManager.LoadScene ("Game");
	}
}
