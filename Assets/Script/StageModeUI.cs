using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageModeUI : MonoBehaviour
{
    private SceneChanger sceneChanger;

    public GameObject AfterOverGame;
    public InputManager Manager;
    public GameObject Buttons;
    public GameObject CreditText;

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = SceneChanger.GetSceneChanger;
    }

    void Update()
    {
        if (!Manager.isWin) return;

        if(!AfterOverGame.activeInHierarchy)
        {
            AfterOverGame.SetActive(true);
            Manager.isThrowable = false;
        }
    }

    public void BackToMain()
    {
        Debug.Log("BTM");

        sceneChanger.ChangeScene("Menu");
    }

    public void Retry()
    {
        Debug.Log("RTY");

        AfterOverGame.SetActive(false);

        Debug.Log("RTY1");

        Manager.isThrowable = true;
        Manager.isWin = false;
    }

    public void Next()
    {
        Debug.Log("NXT");

        string a = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        int stage = int.Parse(a.Split('e')[1]);

        sceneChanger.ChangeScene("Stage" + (stage + 1).ToString());
    }

    public void Option()
    {
        Buttons.SetActive(!Buttons.activeInHierarchy);
    }

    public void ShowCredit()
    {
        CreditText.SetActive(true);
        Buttons.SetActive(false);
    }

    public void UnshowCredit()
    {
        CreditText.SetActive(false);
    }
}
