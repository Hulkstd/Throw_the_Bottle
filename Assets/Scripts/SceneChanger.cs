using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static SceneChanger sceneChanger;
    private static Canvas canvas;
    private static RawImage image;
    private static float fadeSpeed = 16.0f;

    public static SceneChanger GetSceneChanger
    {
        get
        {
            if (sceneChanger)
                return sceneChanger;

            GameObject gameObject = new GameObject("SceneChanger");
            GameObject Imageobject = new GameObject("Fade Object");
            GameObject Canvasobject = new GameObject("Fade Canvas");

            sceneChanger = gameObject.AddComponent<SceneChanger>();
            DontDestroyOnLoad(gameObject);
            
            canvas = Canvasobject.AddComponent<Canvas>();
            Canvasobject.AddComponent<CanvasScaler>();
            Canvasobject.AddComponent<GraphicRaycaster>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvas.sortingOrder = 1;
            CanvasScaler a = canvas.GetComponent<CanvasScaler>();
            a.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            a.referenceResolution = new Vector2(1080, 1920);
            DontDestroyOnLoad(canvas);

            Imageobject.transform.SetParent(canvas.transform);
            image = Imageobject.AddComponent<RawImage>();
            image.rectTransform.localPosition = Vector2.zero;
            image.rectTransform.localScale = Vector2.one * 20;
            image.color = new Color(1,1,1,0);
            image.raycastTarget = false;

            return sceneChanger;
        }
    }

    public void ChangeScene(string Scenename)
    {
        image.raycastTarget = true;
        StartCoroutine(FadeOut(Scenename));
    }

    private IEnumerator FadeIn()
    {
        image.color = new Color(0, 0, 0, 0);
        while (image.color.a >= 0)
        {
            image.enabled = true;
            image.color -= new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }

        image.raycastTarget = false;
    }

    private IEnumerator FadeOut(string SceneName)
    {
        image.enabled = true;
        image.color = new Color(0, 0, 0, 0);
        while (image.color.a <= 1)
        {
            image.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }

        yield return SceneManager.LoadSceneAsync(SceneName);

        StartCoroutine(FadeIn());

        yield return null;
    }

    private IEnumerator FadeOut()
    {
        image.enabled = true;
        while (image.color.a <= 1)
        {
            image.color += new Color(0, 0, 0, fadeSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
