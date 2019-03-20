using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody2D rig;
    public Renderer render;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!render.isVisible)
        {
            InputManager.AddDropped(gameObject, rig);
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            InputManager.AddDropped(gameObject, rig);
            gameObject.SetActive(false);
            // transform.SetParent(null);
            Debug.Log(gameObject.name);
            
        }
    }

}
