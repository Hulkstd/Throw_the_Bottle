using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarMannager : MonoBehaviour
{

    public Scrollbar Scrollbar;
    private float value;
    private float ScrollValue;
    private float StartValue;
    private Vector2 StartPos;
    private Vector2 EndPos;
    

    // Start is called before the first frame update
    void Start()
    {
        Scrollbar.value = 0;
        value = 1 / (float)(StageSetting.ContentsCount - 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartPos = Input.mousePosition;
            StartValue = Scrollbar.value;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndPos = Input.mousePosition;
            ScrollValue = Vector2.Distance(StartPos, EndPos);
            ScrollbarValueChange();
        }
    }

    private void ScrollbarValueChange()
    {
        if (value / 2 < ScrollValue) {
            if (StartPos.x > EndPos.x) {
                if (Scrollbar.value < 1 - value) Scrollbar.value = StartValue + value;
                else Scrollbar.value = 1;
            }
            else {
                if (ScrollValue > value) Scrollbar.value = StartValue - value;
                else Scrollbar.value = 0;
            }
        }
    }
}
