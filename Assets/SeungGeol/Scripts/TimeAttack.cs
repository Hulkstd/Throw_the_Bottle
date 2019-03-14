using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAttack : MonoBehaviour
{
    [SerializeField]
    private InputManager Im;
    [SerializeField]
    public int throwCount = 0;
    public int standCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(30.0f);
        Debug.Log("game set");
        Im.isThrowable = false;
    }

    public void ThrowCntIncrease() => ++throwCount;
    public void StandCntIncrease() => ++standCount;
}
