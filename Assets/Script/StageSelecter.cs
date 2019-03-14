using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelecter : MonoBehaviour
{
    public SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void EnterStage(UnityEngine.UI.Text text)
    {
        sceneChanger.ChangeScene("Stage" + text.text);
    }
}
