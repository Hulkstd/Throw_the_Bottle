using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperUI : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject HelperPanel;
    [SerializeField]
    private Button PrevButton;

    public void OpenHelper()
    {
        HelperPanel.SetActive(true);
        PrevButton.interactable = false;
        animator.SetInteger("Number", 0);
    }

    public void Next()
    {
        if(animator.GetInteger("Number") == 2)
        {
            CloseHelper();
        }
        else
        {
            animator.SetInteger("Number", animator.GetInteger("Number") + 1);
            PrevButton.interactable = true;
        }
    }

    public void Prev()
    {
        animator.SetInteger("Number", animator.GetInteger("Number") - 1);
        PrevButton.interactable = animator.GetInteger("Number") == 0 ? false : true;
    }

    public void CloseHelper()
    {
        HelperPanel.SetActive(false);
    }
}
