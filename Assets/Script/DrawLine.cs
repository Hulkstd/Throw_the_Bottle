using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField]
    private InputManager IM;
    [SerializeField]
    private Material mat;
    [SerializeField]
    private Camera cam;

    private void Start()
    {

    }

    private void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }

        Vector3 vec = IM.endPos - IM.startPos;

        float angle = Mathf.Acos(Vector2.Dot(vec.normalized, Vector2.right)) * Mathf.Rad2Deg;
        Color color = new Color();

        if (vec.sqrMagnitude < 50000.0f)
        {
            color = Color.red;
        }
        else if (vec.sqrMagnitude >= 50000.0f)
        {
            color = Color.white;
        }
        if (angle >= 80.0f || angle <= 10.0f)
        {
            color = Color.red;
        }

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
    
        GL.Begin(GL.LINES);
        GL.Color(Color.white);
        GL.Vertex(new Vector3(IM.startPos.x / Screen.width, IM.startPos.y / Screen.height, 0));
        GL.Color(color);
        GL.Vertex(new Vector3(IM.endPos.x / Screen.width, IM.endPos.y / Screen.height, 0));
        GL.End();
        
        GL.PopMatrix();

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();

        if (IM.isThrowable)
        {
            GL.Begin(GL.LINE_STRIP);
            GL.Color(Color.cyan);

            foreach (Vector2 veca in IM.Moveway)
            {
                GL.Vertex(cam.WorldToViewportPoint(veca) + Vector3.back * 10);
            }
            GL.End();
        }
        GL.PopMatrix();
    }
}
