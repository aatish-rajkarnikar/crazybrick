using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	public Button playAgainButton;
	public Text scoreText;
	public Text bestText;
	// Use this for initialization
	void Start () {
		playAgainButton.onClick.AddListener (StartGame);
		scoreText.text = "SCORE: " + PlayerPrefs.GetInt("score");
		bestText.text = "BEST: " + PlayerPrefs.GetInt ("best");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartGame(){
		SceneManager.LoadScene ("Game");
	}
}
