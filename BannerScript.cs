using System;
using UnityEngine;
using GoogleMobileAds.Api;
using System.Collections;
using System.Diagnostics;

public class BannerScript : MonoBehaviour
{
    private BannerView bannerView;
    
    
    public float time = 15f;

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();
    }
    private void RequestBanner()
    {
        
#if UNITY_ANDROID
        string adUnitId = "gizli";
#elif UNITY_IPHONE
            string adUnitId = "gizli";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        this.bannerView.LoadAd(request);
        //StartCoroutine("Destroy");
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(time);
        bannerView.Destroy();

        
    }
}
