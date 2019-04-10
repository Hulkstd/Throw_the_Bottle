using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instante;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 300;
        if (DontDestroy.Instante)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroy.Instante = this;
        }

        DontDestroyOnLoad(gameObject);   
    }
}
