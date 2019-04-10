using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void ChangeGameScene()
    {
        sceneChanger.ChangeScene("ModeChoose");
    }
}
