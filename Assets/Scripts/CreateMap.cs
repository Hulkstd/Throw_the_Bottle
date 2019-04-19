using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject Stage;
    public GameObject BGImage;
    public List<Transform> gameObjects = new List<Transform>();
    public UnityEngine.UI.InputField input;
    public int Count;

    public void CreateTextFile()
    {
        Count = 0;
        gameObjects.Clear();

        DirectoryInfo di = new DirectoryInfo("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt");
        if (di.Exists)
        {
            File.Delete("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt");
            File.Delete("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt.meta");
        }

        using (StreamWriter streamWriter = new StreamWriter("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt"))
        {
            for (int i = 0; i < Stage.transform.childCount; ++i)
            {
                Transform child = Stage.transform.GetChild(i);
                if (child.childCount > 0)
                {
                    Vector3 Scale = child.localScale;
                    for (int j = 0; j < child.childCount; ++j)
                    {
                        Count++;
                        gameObjects.Add(child.GetChild(j));
                    }
                }
                else
                {
                    Count++;
                    gameObjects.Add(child);
                }
            }

            streamWriter.WriteLine(Count.ToString());

            for (int i = 0; i < gameObjects.Count; i++)
            {
                Transform game = gameObjects[i];

                string str = $"sprite {game.position.x} {game.position.y} " +
                             $"{game.rotation.eulerAngles.x} {game.rotation.eulerAngles.y} {game.rotation.eulerAngles.z} " +
                             $"{game.lossyScale.x} {game.lossyScale.y}";

                streamWriter.WriteLine(str);
            }

            if (BGImage)
            {
                if (BGImage.transform.GetChild(0))
                {
                    Transform trans = BGImage.transform.GetChild(0);

                    SpriteRenderer SP = trans.GetComponent<SpriteRenderer>();

                    string str = $"bg {SP.sprite.name} {SP.transform.position.x} {SP.transform.position.y}" +
                                 $"{SP.transform.rotation.eulerAngles.x} {SP.transform.rotation.eulerAngles.y} {SP.transform.rotation.eulerAngles.z}" +
                                 $"{SP.transform.lossyScale.x} {SP.transform.lossyScale.x}";

                    streamWriter.WriteLine(str);
                }
            }
        }
    }

    public void UnPasing()
    {
        for (int i = Stage.transform.childCount - 1; i >= 0; --i)
        {
            Destroy(Stage.transform.GetChild(i).gameObject);
        }

        using (StreamReader streamReader = new StreamReader("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt"))
        {
            int n = int.Parse(streamReader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string str = streamReader.ReadLine();

                string[] line = str.Split(' ');

                Transform trans = Instantiate(Resources.Load<Transform>("Terrain"));
                trans.position = new Vector3(float.Parse(line[1]), float.Parse(line[2]));
                trans.eulerAngles = new Vector3(float.Parse(line[3]), float.Parse(line[4]), float.Parse(line[5]));
                trans.localScale = new Vector3(float.Parse(line[6]), float.Parse(line[7]), 1);
                trans.SetParent(Stage.transform);
            }
        }
    }
}
