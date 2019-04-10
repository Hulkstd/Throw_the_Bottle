using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [SerializeField]
    public InputManager Im;
    [SerializeField]
    public int throwCount = 0;
    public int standCount = 0;
    public UnityEngine.UI.Text TimeText;
    public bool TimeOver;

    private float Timeleft = 30.0f;
    private bool IsStart;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStart) return;
        Timeleft -= Time.deltaTime / 2;
        TimeText.text = (Timeleft < 0 ? 0 : Timeleft).ToString();
    }

    public void ResetGame()
    {
        Timeleft = 30.0f;
        IsStart = false;
        TimeOver = false;
        TimeText.text = (30.00f).ToString();
        throwCount = 0;
        standCount = 0;
    }

    public void GameStart()
    {
        Im.isThrowable = true;
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        IsStart = true;
        yield return new WaitForSeconds(60.0f);
        Debug.Log("game set");
        Im.isThrowable = false;
        TimeOver = true;

        PlayerGameScript.AddScoreToLeaderboard(GPGSIds.leaderboard_time_attack_ranking, standCount);
        PlayerGameScript.ShowLeaderboardsUI();
    }

    public void ThrowCntIncrease() => ++throwCount;
    public void StandCntIncrease() => ++standCount;
}
