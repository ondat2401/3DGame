using GoogleMobileAds.Api;
using System;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;
    private RewardedAd _rewardedAd;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            
        });
    }

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
        private string _adewardedUnitId = "ca-app-pub-5308213982783971/5659747751"; // Test Ad ID for Android
#elif UNITY_IPHONE
        private string _adewardedUnitId = "ca-app-pub-3940256099942544/1712485313"; // Test Ad ID for iOS
#else
    private string _adewardedUnitId = "unused";
#endif

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // Create the request to load the ad.
      var adRequest = new AdRequest();

        // Load the rewarded ad.
        RewardedAd.Load(_adewardedUnitId, adRequest, (RewardedAd ad, LoadAdError error) =>
        {
            if (error != null || ad == null)
            {
                Debug.LogError("Rewarded ad failed to load an ad with error: " + error);
                return;
            }

            // Set the _rewardedAd to the loaded ad.
            _rewardedAd = ad;
            Debug.Log("Rewarded ad loaded successfully.");

            // Register event handlers for the ad.
            RegisterEventHandlers(ad);

            // Optionally, register the reload handler for the ad.
            RegisterReloadHandler(ad);
        });
    }

    /// <summary>
    /// Shows the rewarded ad if it is ready.
    /// </summary>
    public void ShowRewardedAd()
    {
        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // Handle the reward after the ad is shown.
                Debug.Log(String.Format("Rewarded ad rewarded the user. Type: {0}, amount: {1}.", reward.Type, reward.Amount));
                GameManager.instance.player.GetComponent<PlayerManager>().currentCoin *= 2;
                GameManager.instance.QuitToMenu();
            });
        }
        else
        {
            Debug.Log("Rewarded ad is not ready to be shown.");
        }
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad has paid.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.", adValue.Value, adValue.CurrencyCode));
        };

        // Raised when the ad impression is recorded.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };

        // Raised when the ad is clicked.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };

        // Raised when the ad full screen content is opened.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };

        // Raised when the ad full screen content is closed.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
        };

        // Raised when the ad fails to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error: " + error);
        };
    }

    private void RegisterReloadHandler(RewardedAd ad)
    {
        // Reload the ad when it is closed or fails to show.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            LoadRewardedAd();
        };

        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Rewarded ad failed to open full screen content with error: " + error);
            LoadRewardedAd();
        };
    }
}
