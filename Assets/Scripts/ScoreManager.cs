using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	private int score;

	void Start () {
		score = 0;
	}
	
	void Update () {
		
	}

	public void addScore(){
		score++;
		scoreText.text = "" + score;
	}

	public void saveScore(){
		PlayerPrefs.SetInt("score", score);
		if (score > PlayerPrefs.GetInt ("best") ) {
			PlayerPrefs.SetInt("best", score);
		}
	}
}
