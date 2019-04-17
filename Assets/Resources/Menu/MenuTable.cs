using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTable : MonoBehaviour
{
    public SceneChanger sceneChanger;

    /* 이름 : MenuTable
     * 역할 : 옵션에서 메인 메뉴로 이동할 때 사용
     * 최종작업 날짜 : 2019-03-11 오후 9:48
     * 변경사항 : X
     */

    private void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    public void ChangeGameScene()
    {
        sceneChanger.ChangeScene("Menu");
    }
}