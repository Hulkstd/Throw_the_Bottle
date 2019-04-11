using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public static int StageNum = 1;
    public GameObject Sprite;
    public static List<GameObject> SpawnSprite = new List<GameObject>();

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
    }

    private void OnDisable()
    {
        SpawnSprite.Clear();
    }

    public void SetStageNum(int Num)
    {
        StageNum = Num;
    }

    public void ResetMap()
    {
        Debug.Log(SpawnSprite.Count);

        for (int i = 0; i < SpawnSprite.Count; i++)
        {
            SpawnSprite[i].SetActive(false);
        }

        SpawnSprite.Clear();
    }

    public void ParseMap()
    {
        ResetMap();

        TextAsset textasset = Resources.Load<TextAsset>(Path + StageNum.ToString());

        string[] lines = textasset.text.Split('\n');
        int n = int.Parse(lines[0]);

        GameObject gameObject = Instantiate(new GameObject());
        EscapeBotten es = gameObject.AddComponent<EscapeBotten>();
        es.NowStage = "Stage";
        

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

                        SpawnSprite.Add(gameobject);
                    }
                    break;

                case "bg":
                    {
                        SpriteRenderer SP = Instantiate(new SpriteRenderer());
                        GameObject gameobject = SP.gameObject;

                        var sprites = from sprite in Resources.FindObjectsOfTypeAll<Sprite>()
                                      where sprite.name == texts[1]
                                      orderby sprite.name
                                      select sprite;

                        gameobject.transform.position = new Vector2(float.Parse(texts[2]), float.Parse(texts[3]));
                        gameobject.transform.rotation = Quaternion.Euler(float.Parse(texts[4]), float.Parse(texts[5]), float.Parse(texts[6]));
                        gameobject.transform.localScale = new Vector3(float.Parse(texts[7]), float.Parse(texts[8]), 1);
                    }
                    break;
            }
        }
    }
}
