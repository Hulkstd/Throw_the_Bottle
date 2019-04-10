using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeBotten : MonoBehaviour
{
    SceneChanger sceneChanger;

    public string NowStage;

    private readonly string[] StageStr = { "Menu", "ModeChoose", "Campain" };

    [SerializeField]
    private GameObject Canvar;

    private void Awake()
    {
        sceneChanger = SceneChanger.GetSceneChanger;   
    }

    void Update()
    {
        //if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                switch (NowStage)
                {
                    case "Menu":
                        if (Canvar)
                        {
                            Canvar.SetActive(true);
                        }
                        break;
                    case "ModeChoose":
                        sceneChanger.ChangeScene(StageStr[0]);
                        break;
                    case "Option":
                        sceneChanger.ChangeScene(StageStr[0]);
                        break;
                    case "Campain":
                        sceneChanger.ChangeScene(StageStr[1]);
                        break;
                    case "TimeAttack":
                        sceneChanger.ChangeScene(StageStr[1]);
                        break;
                    case "Stage":
                        sceneChanger.ChangeScene(StageStr[2]);
                        break;
                }
            }
        }
    }

    public void ClickedFalse()
    {
        if (Canvar)
        {
            Canvar.SetActive(false);
        }
        Debug.Log("FalseButton");
    }

    public void ClickedTrue()
    {
        Debug.Log("TrueButton");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");
#else
        Application.Quit();
#endif
    }

}
