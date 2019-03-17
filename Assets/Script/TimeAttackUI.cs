using System.Collections;
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

    public GameObject AfterGameover;
    public Text SuccessCount;
    public Text RankText;

    public TimeAttack timeAttack;

    private SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    private void Update()
    {
        if (!timeAttack.TimeOver) return;

        if (!AfterGameover.activeInHierarchy)
        {
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
        sceneChanger.ChangeScene("ModeChoose");
    }

    public void Retry()
    {
        BeforeGame.SetActive(true);
        PlayButton.onClick.AddListener(TouchToPlay);
        TextAnimator.Play("NormalText");
        BeforeGametext.text = "Click To Play";
        BeforeGametext.transform.localScale = Vector3.one;
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
            yield return new WaitForSeconds(1.0f);
        }

        BeforeGame.SetActive(false);

        timeAttack.GameStart();

        yield return null;
    }
}
