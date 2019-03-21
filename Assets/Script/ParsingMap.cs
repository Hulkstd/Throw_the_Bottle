using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
 * 파싱 형식
 * 
 * line
 * sprite Position Euler Scale
 * bg array_index
 */

public class ParsingMap : MonoBehaviour
{
    public int StageNum = 1;
    public GameObject Sprite;
    public List<Sprite> BGImages = new List<Sprite>();

    public Sprite BGImage1;
    public Sprite BGImage2;
    public Sprite BGImage3;
    public Sprite BGImage4;
    public Sprite BGImage5;
    public Sprite BGImage6;
    public Sprite BGImage7;
    public Sprite BGImage8;
    public Sprite BGImage9;
    public Sprite BGImage10;

    private string Path = "StageMap\\Stage";

    private static ParsingMap instante;
    public static ParsingMap Instante
    {
        get
        {
            if (instante)
                return instante;

            instante = new GameObject("ParsingMap").AddComponent<ParsingMap>();

            DontDestroyOnLoad(instante);

            return instante;
        }
    }

    void OnEnable()
    {
        Sprite = Resources.Load<GameObject>("Terrain");
        BGImages.Clear();
        /*BGImages.Add(BGImage1);
        BGImages.Add(BGImage2);
        BGImages.Add(BGImage3);
        BGImages.Add(BGImage4);
        BGImages.Add(BGImage5);
        BGImages.Add(BGImage6);
        BGImages.Add(BGImage7);
        BGImages.Add(BGImage8);
        BGImages.Add(BGImage9);
        BGImages.Add(BGImage10);*/
    }


    public void SetStageNum(int Num)
    {
        StageNum = Num;
    }

    public void ParseMap()
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
                        GameObject.Find("BackGroundImage").GetComponent<SpriteRenderer>().sprite = BGImages[int.Parse(texts[1])];
                    }
                    break;
            }
        }
    }
}
