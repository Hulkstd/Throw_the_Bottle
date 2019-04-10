using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public void Test()
    {
        PlayerGameScript.ShowLeaderboardsUI();
    }
    
    public void UploadScore()
    {
        PlayerGameScript.AddScoreToLeaderboard(GPGSIds.leaderboard_time_attack_ranking, 10);
    }
}
