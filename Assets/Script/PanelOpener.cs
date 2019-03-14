using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Open;
    public GameObject Close;

    public void OpenPanel()
    {
        if(Panel != null)
        {
            Animator animator = Panel.GetComponent<Animator>();

            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");

                if(!isOpen)
                {
                    Open.SetActive(false);
                    Close.SetActive(true);
                }
                else
                {
                    Open.SetActive(true);
                    Close.SetActive(false);
                }

                animator.SetBool("open", !isOpen);
            }
        }
    }
}
