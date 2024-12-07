using UnityEngine;
using UnityEngine.UI;

public class WatchAdButtonHandler : MonoBehaviour
{
    public void WatchAd()
    {
        // Load and show rewarded ad
        AdsManager.instance.LoadRewardedAd(); 
        AdsManager.instance.ShowRewardedAd(); 
    }
}
