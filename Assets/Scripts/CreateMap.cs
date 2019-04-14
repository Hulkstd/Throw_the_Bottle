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
                             $"{game.localScale.x} {game.localScale.y}";

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
                                 $"{SP.transform.localScale.x} {SP.transform.localScale.x}";

                    streamWriter.WriteLine(str);
                }
            }
        }
    }
}
