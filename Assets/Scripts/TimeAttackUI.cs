﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeAttackUI : MonoBehaviour
{
    public GameObject BeforeGame;
    public Button PlayButton;
    public Text BeforeGametext;
    public Animator TextAnimator;
    public Text ScoreText;

    public GameObject AfterGameover;
    public Text SuccessCount;
    public Text RankText;

    public TimeAttack timeAttack;

    public GameObject Buttons;
    public GameObject CreditText;

    private SceneChanger sceneChanger;

    private void Start()
    {
        Time.timeScale = 2.0f;

        PlayButton.onClick.AddListener(delegate() { TouchToPlay(); });
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    private void Update()
    {
        if (!timeAttack.TimeOver)
        {
            ScoreText.gameObject.SetActive(true);
            ScoreText.text = timeAttack.standCount.ToString();

            return;
        }

        if (!AfterGameover.activeInHierarchy)
        {
            ScoreText.gameObject.SetActive(false);
            AfterGameover.SetActive(true);
            SuccessCount.text = "Hit : " + timeAttack.standCount.ToString();
        }
    }

    public void TouchToPlay()
    {
        PlayButton.onClick.RemoveAllListeners();
        StartCoroutine(Play());
    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        sceneChanger.ChangeScene("ModeChoose");
    }

    public void Retry()
    {
        BeforeGame.SetActive(true);
        TextAnimator.Play("NormalText");
        BeforeGametext.text = "Click To Play";
        BeforeGametext.transform.localScale = Vector3.one;
        PlayButton.onClick.AddListener(delegate () { TouchToPlay(); });
        AfterGameover.SetActive(false);
        timeAttack.ResetGame();
        timeAttack.Im.ResetGame();
    }
        
    IEnumerator Play()
    {
        BeforeGametext.text = "6";

        while (int.Parse(BeforeGametext.text) != 0)
        {
            BeforeGametext.text = (int.Parse(BeforeGametext.text) - 1).ToString();
            TextAnimator.Play("BigtoSmall");
            yield return new WaitForSeconds(2.0f);
        }

        BeforeGame.SetActive(false);

        timeAttack.GameStart();

        yield return null;
    }
    
    public void Option()
    {
        Buttons.SetActive(!Buttons.activeInHierarchy);
    }

    public void ShowCredit()
    {
        CreditText.SetActive(true);
        Buttons.SetActive(false);
    }

    public void UnshowCredit()
    {
        CreditText.SetActive(false);
    }
}
