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
        color = Color.white;

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadOrtho();
    
        GL.Begin(GL.LINES);
        GL.Color(color);
        //  Debug.LogWarning(Camera.main.WorldToViewportPoint(IM.startPos) - Vector3.forward * 10);
        GL.Vertex(Camera.main.WorldToViewportPoint(IM.startPos) - Vector3.forward * 10);
        GL.Vertex(Camera.main.WorldToViewportPoint(IM.endPos) - Vector3.forward * 10);
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
