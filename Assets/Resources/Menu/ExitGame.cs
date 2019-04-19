using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    /* 이름 : ExitGame
     * 역할 : 메인 메뉴에서 게임 종료하기
     * 최종작업 날짜 : 2019-03-12 오전 8:26
     * 변경사항 : X
     */

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");
    #else
        Application.Quit();
    #endif

        /* 유니티 에디터에서 실행해보기 위한 코드임
         * 실제로 게임할때에는 Application.Quit();만 있어도 충분함
         */ 
    }
}