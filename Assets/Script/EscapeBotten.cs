using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeBotten : MonoBehaviour
{

    public string NowStage;

    private readonly string[] StageStr = { "Menu", "ModeChoose", "Campain" };

    private bool InGame;

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                switch (NowStage)
                {
                    case "Menu":
                        Application.Quit();
                        break;
                    case "ModeChoose":
                        SceneManager.LoadScene(StageStr[0]);
                        break;
                    case "Option":
                        SceneManager.LoadScene(StageStr[0]);
                        break;
                    case "Campain":
                        SceneManager.LoadScene(StageStr[1]);
                        break;
                    case "TimeAttack":
                        if (!InGame)
                        {
                            SceneManager.LoadScene(StageStr[1]);
                        }
                        break;
                    case "Stage":
                        SceneManager.LoadScene(StageStr[2]);
                        break;
                }
            }
        }
    }
}
