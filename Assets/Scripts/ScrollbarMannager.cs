using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarMannager : MonoBehaviour
{

    public Scrollbar Scrollbar;
    private float value;
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

        if (Input.GetMouseButtonUp(0))
        {
            EndPos = Input.mousePosition;
            ScrollbarValueChange();
        }
    }

    private void ScrollbarValueChange()
    {
        if (value / 2 < Mathf.Abs(Scrollbar.value - StartValue))
        {
            if (StartPos.x > EndPos.x)
            {
                if (Mathf.Abs(Scrollbar.value - StartValue) < 1 - value) Scrollbar.value = StartValue + value;
                else Scrollbar.value = 1;
            }
            else
            {
                if (Mathf.Abs(Scrollbar.value - StartValue) > value) Scrollbar.value = StartValue - value;
                else Scrollbar.value = 0;
            }
        }
        else
        {
            Scrollbar.value = StartValue;
        }
    }
}
