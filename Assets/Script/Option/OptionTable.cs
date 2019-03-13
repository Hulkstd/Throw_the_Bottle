using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionTable : MonoBehaviour
{
    public SceneChanger sceneChanger;

    /* 이름 : OptionTable
     * 역할 : 메인 메뉴에서 옵션 메뉴로 이동할 때 사용
     * 최종작업 날짜 : 2019-03-11 오후 9:46
     * 변경사항 : X
     */

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void ChangeGameScene()
    {
        sceneChanger.ChangeScene("Option");
    }
}