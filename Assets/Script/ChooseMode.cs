using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseMode : MonoBehaviour
{
    public SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void StageMode()
    {
        sceneChanger.ChangeScene("Champain");
    }

    public void BurstMode()
    {
        sceneChanger.ChangeScene("TimeAttack");
    }
}
