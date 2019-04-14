using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdsHelper : MonoBehaviour
{
    public static UnityAdsHelper Instance { get; private set; }

    private const string android_game_id = "3110616";
    private const string ios_game_id = "3110617";

    private const string rewarded_video_id = "rewardedVideo";
    private const string video_id = "video";
    private const string banner_id = "banner";

    private int FuncCallCount = 0;


    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
        Initialize();
        StartCoroutine(BannerLoop());
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
#endif
    }

    public void ShowRewardedAd()
    {
        //text.text = Advertisement.IsReady(rewarded_video_id).ToString();

        FuncCallCount++;

        if(FuncCallCount < 3)
        {
            return;
        }

        FuncCallCount = 0;

        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    public void ShowAd()
    {
        //text.text = Advertisement.IsReady(video_id).ToString();

        FuncCallCount++;

        if (FuncCallCount < 3)
        {
            return;
        }

        FuncCallCount = 0;

        if (Advertisement.IsReady(video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    // todo ...
                    // 광고 시청이 완료되었을 때 처리
                }
                break;

            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // todo ...
                    // 광고가 스킵되었을 때 처리
                }
                break;

            case ShowResult.Failed:
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
        while(true)
        {
            yield return ShowBannerWhenReady();
        }
    }

    IEnumerator ShowBannerWhenReady()
    { 
        while (!Advertisement.IsReady(banner_id))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Show(banner_id);
    }
}
