using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    [SerializeField]
    private Animator ohAnim;
    [SerializeField]
    private Transform Bottle;
    [SerializeField]
    private Collider2D BottleCol;
    [SerializeField]
    private Rigidbody2D BottleRd2d;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isThrowable = true;
    //private Vector2 direction;
    
	// Use this for initialization
	void Start () {
        
	}
	
    void Update()
    {
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        if (!isThrowable) return;
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            ThrowBottle();
        }
    }

    private void ThrowBottle()
    {
        Vector2 vec = (endPos - startPos);
        Debug.Log(vec.sqrMagnitude);

        float angle = Mathf.Acos(Vector2.Dot(vec.normalized, Vector2.right)) * Mathf.Rad2Deg;
        //dot ab = cos theta = x
        //acos x = theta

        if (angle >= 80.0f || angle <= 10.0f)
        {
            Debug.Log("throw lower or higher");
            return;
        }


        if (vec.sqrMagnitude < 50000.0f)
        {
            Debug.Log("Throw stronger");
            return;
        }

        if (vec.sqrMagnitude > 275000.0f)
        {
            vec.Normalize();
            vec *= 800.0f;
        }

        BottleRd2d.AddForceAtPosition(vec, Bottle.position + Vector3.down * BottleCol.bounds.size.y);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        isThrowable = false;
        float timer = 0.0f;
        yield return new WaitUntil(() =>
        {
            if (Mathf.Abs(BottleRd2d.angularVelocity) <= 0.01f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0.0f;
            }

            return (timer >= 1.0f) ? true : false;
        }
        );

        if (Physics2D.Raycast(Bottle.position + -Bottle.up * BottleCol.bounds.extents.y, -Bottle.up, 0.1f, 1 << 8))
        {
            Debug.Log("ohhhh");
            ohAnim.Play("Ohhhh");
        }
        else if (Physics2D.Raycast(Bottle.position + Bottle.up * BottleCol.bounds.extents.y, Bottle.up, 0.1f, 1 << 8))
        {
            Debug.Log("ohhhh");
            ohAnim.Play("Ohhhh");
        }

        //Debug.Log("Reset");
        Bottle.position = new Vector2(-2.7f, 0.5f);
        BottleRd2d.velocity = Vector2.zero;
        BottleRd2d.angularVelocity = 0.0f;
        Bottle.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        isThrowable = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(Bottle.position + -Bottle.up * BottleCol.bounds.extents.y,
            Bottle.position + -Bottle.up * BottleCol.bounds.extents.y + -Bottle.up);
        Gizmos.DrawLine(Bottle.position + Bottle.up * BottleCol.bounds.extents.y,
    Bottle.position + Bottle.up * BottleCol.bounds.extents.y + Bottle.up);
    }
}
