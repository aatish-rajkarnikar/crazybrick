using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds;


public class AdsManager : MonoBehaviour {

	BannerView bannerView;
	InterstitialAd interstitial;
	void Start () {
		RequestBanner();
		RequestInterstitial ();
	}
	
	// Update is called once per frame
	void Update () {
		
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

		bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);

		//bannerView.OnAdLoaded += HandleOnAdLoaded;

		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
	}

	private void RequestInterstitial(){
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-5492969470059595/2519720709";
		#elif UNITY_IPHONE
		string adUnitId = "ca-app-pub-5492969470059595/4554937626";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder().Build();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
	}

	 public void ShowInterstitialAd()	{
		if (interstitial.IsLoaded()) {
			interstitial.Show();
		}
	}

		//	public void HandleOnAdLoaded(object sender, EventArgs args)	{
		//		print("OnAdLoaded event received.");
		//		// Handle the ad loaded event.
		//		bannerView.Show();
		//	}

}
