using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Rigidbody2D Rig;
    bool isGet;

    // Start is called before the first frame update
    void Start()
    {
        isGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && !isGet)
        {
            Rig.AddForceAtPosition(Vector2.one * 80, Vector2.down * 3, ForceMode2D.Impulse);
            Rig.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
            isGet = true;
        }
    }
}
