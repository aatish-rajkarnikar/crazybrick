using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class Dimond : MonoBehaviour {

	private float upForce = 400;
	private float directionalForce = 150;

	private bool isDead = false;
	private Rigidbody2D rigidbody2d;
 	
	BannerView bannerView;

	void Start () {
		rigidbody2d = GetComponent<Rigidbody2D> ();
		RequestBanner();
	}
	
	void Update () {
		if (!isDead) {
			Touch[] touches = Input.touches;
			foreach (Touch touch in touches) {
				if (touch.position.x < Screen.width/2 && touch.phase == TouchPhase.Began) {
					rigidbody2d.velocity = Vector2.zero;
					rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
				}
				else if (touch.position.x > Screen.width/2 && touch.phase == TouchPhase.Began) {
					rigidbody2d.velocity = Vector2.zero;
					rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
				} 
			}

			if (Input.GetKeyDown (KeyCode.A)) {
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(-directionalForce, upForce));
			}else if (Input.GetKeyDown(KeyCode.S)) {
				rigidbody2d.velocity = Vector2.zero;
				rigidbody2d.AddForce (new Vector2(directionalForce, upForce));
			}
		}
	}
		
	private void RequestBanner(){
		#if UNITY_EDITOR
		string adUnitId = "unused";
		#elif UNITY_ANDROID
		string adUnitId = "ca-app-pub-5492969470059595/3742492403";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5492969470059595/6944081250";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Create a 320x50 banner at the top of the screen.
		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

		//bannerView.OnAdLoaded += HandleOnAdLoaded;
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the banner with the request.
		bannerView.LoadAd(request);
	}

//	public void HandleOnAdLoaded(object sender, EventArgs args)	{
//		print("OnAdLoaded event received.");
//		// Handle the ad loaded event.
//		bannerView.Show();
//	}


	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			isDead = true;
			gameObject.GetComponent<Collider2D> ().enabled = false;
			Invoke ("GameOver", 2);
		}
	}
	
	void GameOver(){
		SceneManager.LoadScene ("GameOver");	
	}
	
}
