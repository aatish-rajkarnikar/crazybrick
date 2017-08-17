using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Dimond : MonoBehaviour {

	private float upForce = 400;
	private float directionalForce = 150;

	private bool isDead = false;
	private Rigidbody2D rigidbody2d;
 	
	public AudioClip[] clips;
	private ScoreManager scoreManager;
	private AdsManager adsManager;
	private AudioSource audioSource;

	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			scoreManager = gameControllerObject.GetComponent <ScoreManager>();
			adsManager = gameControllerObject.GetComponent<AdsManager> ();
		}
	}
	
	void Update () {
		if (!isDead) {
			Touch touch = Input.GetTouch (0);
			if (touch.position.x < Screen.width/2 && touch.phase == TouchPhase.Began) {
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
				playSound (0);
			}
			else if (touch.position.x > Screen.width/2 && touch.phase == TouchPhase.Began) {
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
				playSound (0);
			} 
//			if (Input.GetKeyDown (KeyCode.A)) {
//				rigidbody2d.velocity = Vector2.zero;
//				rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
//				playSound (0);
//			}else if (Input.GetKeyDown(KeyCode.S)) {
//				rigidbody2d.velocity = Vector2.zero;
//				rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
//				playSound (0);
//			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			isDead = true;
			rigidbody2d.velocity = Vector2.zero;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			scoreManager.saveScore ();
			Invoke ("GameOver", 2);
			playSound (1);
		}
	}
	
	void GameOver(){
		adsManager.ShowInterstitialAd ();
		SceneManager.LoadScene ("GameOver");	
	}

	void playSound(int clipIndex){
		audioSource.clip = clips [clipIndex];
		audioSource.Play ();
	}
}
