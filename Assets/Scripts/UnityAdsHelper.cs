using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames.BasicApi;
using GooglePlayGames;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class UnityAdsHelper : MonoBehaviour
{
    public static UnityAdsHelper Instance { get; private set; }

#if UNITY_ANDROID
    private const string game_id = "3110616";
#elif UNITY_IOS
    private const string game_id = "3110617";
#elif UNITY_EDITOR
    private const string game_id = "1111111";
#endif

    private const string rewarded_video_id = "rewardedVideo";
    private const string video_id = "video";
    private const string banner_id = "banner";

    [SerializeField]
    private int FuncCallCount = 0;
    [SerializeField]
    private UnityEngine.UI.Text text;
    private bool BannerEnd = true;

    private void Awake()
    {
        if(UnityAdsHelper.Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            UnityAdsHelper.Instance = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {

        Debug.Log("1");
        Debug.Log(Monetization.isInitialized.ToString());
        text.text = Monetization.isInitialized.ToString();
        Initialize();
        Debug.Log("3");
        Debug.Log(Monetization.isInitialized.ToString());
        text.text = Monetization.isInitialized.ToString();
        Debug.Log("4");
        StartCoroutine(BannerLoop());
    }

    private void Initialize()
    {
        Debug.Log("2");

        Debug.Log(Monetization.isSupported.ToString());
        if (Monetization.isSupported)
        {
            Monetization.Initialize(game_id, false);
        }
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize(game_id, false);
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        }
    }

    public void ShowRewardedAd()
    {
        FuncCallCount++;

        if (FuncCallCount < 3)
        {
            return;
        }

        FuncCallCount = 0;

        if (Monetization.IsReady(video_id))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_id) as ShowAdPlacementContent;
            
            if(ad != null)
            {
                ad.Show();
            }
        }
    }

    public void ShowAd()
    {
        FuncCallCount++;
        Debug.Log(FuncCallCount);

        if (FuncCallCount < 3)
        {
            return;
        }

        FuncCallCount = 0;

        if (Monetization.IsReady(video_id))
        {
            Debug.Log("Video Ready!");
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(video_id) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    private void HandleShowResult(UnityEngine.Advertisements.ShowResult result)
    {
        switch (result)
        {
            case UnityEngine.Advertisements.ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    // todo ...
                    // 광고 시청이 완료되었을 때 처리
                }
                break;

            case UnityEngine.Advertisements.ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // todo ...
                    // 광고가 스킵되었을 때 처리
                }
                break;

            case UnityEngine.Advertisements.ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // todo ...
                    // 광고 시청에 실패했을 때 처리
                }
                break;
        }
    }

    IEnumerator BannerLoop()
    {
        while (true)
        {
            yield return StartCoroutine(ShowBannerWhenReady());

            while (true)
            {
                if (BannerEnd)
                {
                    Debug.Log("Banner");
                    yield return new WaitForSeconds(30.0f);
                    break;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }

    IEnumerator ShowBannerWhenReady()
    {
        Debug.Log("Banner NotReady");
        while (!Advertisement.IsReady(banner_id))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Debug.Log("Banner Ready");
        BannerEnd = false;

        Advertisement.Banner.Show(banner_id, new BannerOptions() { hideCallback = () => { BannerEnd = true; } });
    }
}
