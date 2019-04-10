using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeStage : MonoBehaviour
{
    private void Start()
    {
        ParsingMap.Instante.ParseMap();
    }
}
