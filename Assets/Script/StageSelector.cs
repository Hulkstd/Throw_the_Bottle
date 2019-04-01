using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelector : MonoBehaviour
{
    public SceneChanger sceneChanger;

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void EnterStage(UnityEngine.UI.Text text)
    {
        ParsingMap.Instante.SetStageNum(int.Parse(text.text));
        sceneChanger.ChangeScene("Stage");
    }
}
