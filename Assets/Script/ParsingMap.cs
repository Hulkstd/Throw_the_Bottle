using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 파싱 형식
 * 
 * line
 * sprite Position Euler Scale
 * bg array_index
 */

public class ParsingMap : MonoBehaviour
{
    public static int StageNum = 1;
    public static GameObject Sprite;
    public static Sprite[] BGImage;
    public static string Path = "StageMap\\Stage";

    public static void SetStageNum(int Num)
    {
        StageNum = Num;
    }

    public static void ParseMap()
    {
        TextAsset textasset = Resources.Load<TextAsset>(Path + StageNum.ToString());

        string[] lines = textasset.text.Split('\n');
        int n = int.Parse(lines[0]);

        for (int i = 1; i <= n; i++)
        {
            string[] texts = lines[i].Split(' ');
            switch(texts[0])
            {
                case "sprite":
                    {
                        GameObject gameobject = Instantiate(Sprite);

                        gameobject.transform.position = new Vector2(float.Parse(texts[1]), float.Parse(texts[2]));
                        gameobject.transform.rotation = Quaternion.Euler(float.Parse(texts[3]), float.Parse(texts[4]), float.Parse(texts[5]));
                        gameobject.transform.localScale = new Vector3(float.Parse(texts[6]), float.Parse(texts[7]), 1);
                    }
                    break;

                case "bg":
                    {
                        GameObject.Find("BackGroundImage").GetComponent<SpriteRenderer>().sprite = BGImage[int.Parse(texts[1])];
                    }
                    break;
            }
        }
    }
}
