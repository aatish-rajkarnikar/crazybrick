using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Dimond : MonoBehaviour {

	public Button startButton;

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
	
	void FixedUpdate () {
		if (!isDead) {
//			Touch touch = Input.GetTouch (0);
//			if (touch.position.x < Screen.width/2 && touch.phase == TouchPhase.Began) {
//				rigidbody2d.velocity = Vector2.zero;
//				rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
//				playSound (0);
//			}
//			else if (touch.position.x > Screen.width/2 && touch.phase == TouchPhase.Began) {
//				rigidbody2d.velocity = Vector2.zero;
//				rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
//				playSound (0);
//			} 
			if (Input.GetKeyDown (KeyCode.A)) {
				rigidbody2d.gravityScale = 1;
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
				playSound (0);
			}else if (Input.GetKeyDown(KeyCode.S)) {
				rigidbody2d.gravityScale = 1;
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
				playSound (0);
			}
		}
	}

	void Update(){
		if (!isDead) {
			if (transform.position.x > 3.5 || transform.position.x < -3.5 || transform.position.y < -6) {
				GameOver ();
			}
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			GameOver ();
		}
	}
	
	void GameOver(){
		isDead = true;
		rigidbody2d.velocity = Vector2.zero;
		gameObject.GetComponent<Collider2D> ().enabled = false;
		scoreManager.saveScore ();
		Invoke ("ShowGameOverScene", 2);
		playSound (1);
			
	}

	void ShowGameOverScene(){
		SceneManager.LoadScene ("GameOver");
		adsManager.ShowInterstitialAd ();
	}

	void playSound(int clipIndex){
		audioSource.clip = clips [clipIndex];
		audioSource.Play ();
	}
}
