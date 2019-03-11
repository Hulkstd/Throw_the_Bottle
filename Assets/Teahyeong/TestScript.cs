using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Rigidbody2D Rig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rig.AddForceAtPosition(Vector2.one * 25, Vector2.down * 3, ForceMode2D.Impulse);
            Rig.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
        }
    }
}
