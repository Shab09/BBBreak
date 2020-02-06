using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class LoadAds : MonoBehaviour {
    private BannerView bannerView;
    private InterstitialAd interstitial;
    public void Start () {
        string appId = "ca-app-pub-7270896592886647~8457578280";
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize (appId);

        this.RequestBanner ();
        this.RequestInterstitial ();

    }

    //Function to request banner ad
    private void RequestBanner () {
        string adUnitId = "ca-app-pub-7270896592886647/1892169936";
        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView (adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder ().AddTestDevice("CBEBBBC0810EE3C4").Build ();

        // Load the banner with the request.
        this.bannerView.LoadAd (request);
        // Called when an ad request has successfully loaded.
        this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
        // Called when an ad is clicked.
        this.bannerView.OnAdOpening += this.HandleOnAdOpened;
        // Called when the user returned from the app after an ad click.
        this.bannerView.OnAdClosed += this.HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;
    }

    //Function to request interstitial ad
    private void RequestInterstitial () {

        string adUnitId = "ca-app-pub-7270896592886647/7611400475";

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd (adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder ().AddTestDevice("CBEBBBC0810EE3C4").Build ();
        // Load the interstitial with the request.
        this.interstitial.LoadAd (request);
    }

    //Display Ad when game is over
    public void gameover  () {
        //Check if ad is loaded
        Debug.Log("Chck show ad");
        if (this.interstitial.IsLoaded ()) {
            Debug.Log("Showing Ad");
            this.interstitial.Show ();
        }
    }

    #region BannarAdHandler
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdClosed event received");
    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    #endregion
}