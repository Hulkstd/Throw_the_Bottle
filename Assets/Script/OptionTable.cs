using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionTable : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Option");
    }
}