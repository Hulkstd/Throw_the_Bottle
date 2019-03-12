using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Rigidbody2D Rig;

    // Start is called before the first frame update
    void Start()
    {
        Rig.AddForceAtPosition(Vector2.one * 5, Vector2.down * 3,ForceMode2D.Impulse);
        Rig.AddForce(Vector2.right * 20, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
