using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollbarMannager : MonoBehaviour
{
    [SerializeField]
    private Scrollbar Scrollbar;

    private float IncreaseValue;

    private bool IsIncrease;
    private bool IsScroll;
    private float Value;

    private float StartValue;
    private float EndValue;

    private float TargetValue;
   
    private void Start()
    {
        IsScroll = true;
        Value = 1f / (StageSetting.ContentsCount - 1);
        IncreaseValue = Value / 10;
    }

    private void Update()
    {
        if (IsScroll)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Down");
                StartValue = Scrollbar.value;
            }
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Up");
                EndValue = Scrollbar.value;
                if (StartValue < EndValue) { IsIncrease = true; }
                else if (StartValue > EndValue) { IsIncrease = false; }
                else { return; }
                IsIncrease = StartValue < EndValue ? true : false;

                Debug.Log("Scrollbar value : " + Scrollbar.value + " IsIncrease " + IsIncrease);
                Debug.Log(" + ? => " + !(Scrollbar.value == 1 && IsIncrease) + " - ? ->" + !(Scrollbar.value == 0 && !IsIncrease));

                if (!(Scrollbar.value == 1 && IsIncrease) && !(Scrollbar.value == 0 && !IsIncrease))
                {
                    Debug.Log("Start Coroutine");
                    IsScroll = false;
                    StartCoroutine("DoScroll");
                }
            }
        }
        

    }

    IEnumerator DoScroll()
    {
        TargetValue = StartValue + (IsIncrease ? Value : -Value);

        Debug.Log("Do Coroutine  target : " + TargetValue);

        while (Scrollbar.value != TargetValue) {
            IsIncrease = TargetValue > Scrollbar.value ? true : false;
            if (Mathf.Abs(TargetValue - Scrollbar.value) < IncreaseValue)
            {
                Scrollbar.value = TargetValue;
                break;
            }
            Scrollbar.value += IsIncrease ? IncreaseValue : -IncreaseValue;
            yield return new WaitForSeconds(0.025f);
        }

        IsScroll = true;
    }

}
