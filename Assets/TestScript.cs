using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            Rig.AddForceAtPosition(Vector2.one * 120, Vector2.down * 3, ForceMode2D.Impulse);
            Rig.AddForce(Vector2.right * 200, ForceMode2D.Impulse);
            isGet = true;
        }
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }
    }
}
