using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Button playAgainButton;
	// Use this for initialization
	void Start () {
		playAgainButton.onClick.AddListener (StartGame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame(){
		SceneManager.LoadScene ("Game");
	}
}
