using System;
using UnityEngine;
using UnityEngine.Events;
using GoogleMobileAds.Api;

[System.Serializable]
public class OnODUL : UnityEvent<double>{
}

// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class VG_GoogleAdmob : MonoBehaviour
{      
    

    private AdRequest CreateAdRequest(){
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    public OnODUL OdulVer;
    

    [Header("Android")]

    public VGAdmobID AndroidID= new VGAdmobID(){
        AppID = "ca-app-pub-3940256099942544~3347511713",
        BannerID = "ca-app-pub-3940256099942544/6300978111",
        RewardID = "ca-app-pub-3940256099942544/5224354917",
        InterstitialID = "ca-app-pub-3940256099942544/1033173712",

    };
    [Header("IOS")]
    public VGAdmobID IOSID = new VGAdmobID(){
        AppID = "ca-app-pub-3940256099942544~1458002511",
        BannerID = "ca-app-pub-3940256099942544/2934735716",
        RewardID = "ca-app-pub-3940256099942544/1712485313",
        InterstitialID = "ca-app-pub-3940256099942544/4411468910",

    };




 
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardBasedVideoAd rewardBasedVideo;
    private static string outputMessage = string.Empty;

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }

    public void Start()
    {

#if UNITY_ANDROID
        // string appId = "ca-app-pub-3940256099942544~3347511713";
        string appId = AndroidID.AppID;
#elif UNITY_IPHONE
        // string appId = "ca-app-pub-3940256099942544~1458002511";
        string appId = IOSID.AppID;
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so rs should only be registered once.
        this.rewardBasedVideo.OnAdLoaded += this.RewardBasedVideoLoaded;
        this.rewardBasedVideo.OnAdFailedToLoad += this.RewardBasedVideoFailedToLoad;
        this.rewardBasedVideo.OnAdOpening += this.RewardBasedVideoOpened;
        this.rewardBasedVideo.OnAdStarted += this.RewardBasedVideoStarted;
        this.rewardBasedVideo.OnAdRewarded += this.RewardBasedVideoRewarded;
        this.rewardBasedVideo.OnAdClosed += this.RewardBasedVideoClosed;
        this.rewardBasedVideo.OnAdLeavingApplication += this.RewardBasedVideoLeftApplication;
    }


    public void OnGUI2()
    {
        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        style.alignment = TextAnchor.LowerRight;
        style.fontSize = (int)(Screen.height * 0.06);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        // float fps = 1.0f / this.deltaTime;
        string text = string.Format("{0:0.} fps", 0101);
        GUI.Label(rect, text, style);

        // Puts some basic buttons onto the screen.
        GUI.skin.button.fontSize = (int)(0.035f * Screen.width);
        float buttonWidth = 0.35f * Screen.width;
        float buttonHeight = 0.15f * Screen.height;
        float columnOnePosition = 0.1f * Screen.width;
        float columnTwoPosition = 0.55f * Screen.width;

        Rect requestBannerRect = new Rect(
            columnOnePosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestBannerRect, "Request\nBanner Top"))
        {
            this.RequestBanner(AdPosition.Top);
        }

        Rect destroyBannerRect = new Rect(
            columnOnePosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyBannerRect, "Destroy\nBanner"))
        {
            this.bannerView.Destroy();
        }

        Rect requestInterstitialRect = new Rect(
            columnOnePosition,
            0.4f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestInterstitialRect, "Request\nInterstitial"))
        {
            this.RequestInterstitial();
        }

        Rect showInterstitialRect = new Rect(
            columnOnePosition,
            0.575f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showInterstitialRect, "Show\nInterstitial"))
        {
            this.ShowInterstitial();
        }

        Rect destroyInterstitialRect = new Rect(
            columnOnePosition,
            0.75f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyInterstitialRect, "Destroy\nInterstitial"))
        {
            this.interstitial.Destroy();
        }

        Rect requestRewardedRect = new Rect(
            columnTwoPosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestRewardedRect, "Request\nRewarded Video"))
        {
            this.RequestRewardBasedVideo();
        }

        Rect showRewardedRect = new Rect(
            columnTwoPosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showRewardedRect, "Show\nRewarded Video"))
        {
            this.ShowRewardBasedVideo();
        }

        Rect textOutputRect = new Rect(
            columnTwoPosition,
            0.925f * Screen.height,
            buttonWidth,
            0.05f * Screen.height);
        GUI.Label(textOutputRect, outputMessage);
    }

    // Returns an ad request with custom ad targeting.
  

    public void DestroyBanner(){
               this.bannerView.Destroy();
    }
    public void RequestBanner(AdPosition poz)
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        // string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        string adUnitId = AndroidID.BannerID;
#elif UNITY_IPHONE
        // string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        string adUnitId = IOSID.BannerID;
#else
        string adUnitId = "unexpected_platform";
#endif
        

        // Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, poz);

        // Register for ad events.
        this.bannerView.OnAdLoaded += this.AdLoaded;
        this.bannerView.OnAdFailedToLoad += this.AdFailedToLoad;
        this.bannerView.OnAdOpening += this.AdOpened;
        this.bannerView.OnAdClosed += this.AdClosed;
        this.bannerView.OnAdLeavingApplication += this.AdLeftApplication;

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        // string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        string adUnitId = AndroidID.InterstitialID;
#elif UNITY_IPHONE
        // string adUnitId = "ca-app-pub-3940256099942544/4411468910";
        string adUnitId = IOSID.InterstitialID;
#else
        string adUnitId = "unexpected_platform";
#endif
        
        
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        this.interstitial.OnAdLoaded += this.InterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.InterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.InterstitialOpened;
        this.interstitial.OnAdClosed += this.InterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.InterstitialLeftApplication;

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }
    // public UnityEngine.UI.Text Yazi;
    public void RequestRewardBasedVideo()
    {
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        // string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        string adUnitId = AndroidID.RewardID;
        // if (Yazi != null)
        // {
        //     Yazi.text = "NormalID";
        // }
#elif UNITY_IPHONE
        // string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        string adUnitId = IOSID.RewardID;
#else
        string adUnitId = "unexpected_platform";
#endif

    // 
    // 
        this.rewardBasedVideo.LoadAd(this.CreateAdRequest(), adUnitId);
    }

    public void ShowInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial is not ready yet");
        }
    }

    public void ShowRewardBasedVideo()
    {
        if (this.rewardBasedVideo.IsLoaded())
        {
            this.rewardBasedVideo.Show();
        }
        else
        {
            RequestRewardBasedVideo();
            Debug.Log("Reward based video ad is not ready yet");
        }
    }

    #region Banner callback rs

    public void AdLoaded(object sender, EventArgs args)
    {
        Debug.Log("AdLoaded event received");
    }

    public void AdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("FailedToReceiveAd event received with message: " + args.Message);
    }

    public void AdOpened(object sender, EventArgs args)
    {
        Debug.Log("AdOpened event received");
    }

    public void AdClosed(object sender, EventArgs args)
    {
        Debug.Log("AdClosed event received");
    }

    public void AdLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("AdLeftApplication event received");
    }

    #endregion

    #region Interstitial callback rs

    public void InterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("InterstitialLoaded event received");
    }

    public void InterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(
            "InterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void InterstitialOpened(object sender, EventArgs args)
    {
        Debug.Log("InterstitialOpened event received");
    }

    public void InterstitialClosed(object sender, EventArgs args)
    {
        RequestInterstitial();
        Debug.Log("InterstitialClosed event received");
    }

    public void InterstitialLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("InterstitialLeftApplication event received");
    }

    #endregion

    #region RewardBasedVideo callback rs

    public void RewardBasedVideoLoaded(object sender, EventArgs args)
    {
        Debug.Log("RewardBasedVideoLoaded event received");
    }

    public void RewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(
            "RewardBasedVideoFailedToLoad event received with message: " + args.Message);
    }

    public void RewardBasedVideoOpened(object sender, EventArgs args)
    {
        Debug.Log("RewardBasedVideoOpened event received");
    }

    public void RewardBasedVideoStarted(object sender, EventArgs args)
    {
        Debug.Log("RewardBasedVideoStarted event received");
    }

    public void RewardBasedVideoClosed(object sender, EventArgs args)
    {
        Debug.Log("RewardBasedVideoClosed event received");
        // Yazi.text = "Video Kapandi";
        RequestRewardBasedVideo();
    }

    public void RewardBasedVideoRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log(
            "RewardBasedVideoRewarded event received for " + amount.ToString() + " " + type);
        OdulVer.Invoke(amount);
        RequestRewardBasedVideo();
    }

    public void RewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("RewardBasedVideoLeftApplication event received");
    }

    #endregion
}



[System.Serializable]public class VGAdmobID{
    public string AppID;
    public string BannerID;
    public string RewardID;
    public string InterstitialID;
}
