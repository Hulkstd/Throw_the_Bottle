using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject Stage;
    public GameObject BGImage;
    public UnityEngine.UI.InputField input;

    public void CreateTextFile()
    {
        using (StreamWriter streamWriter = new StreamWriter("Assets\\Resources\\StageMap\\Stage" + input.text + ".txt"))
        {
            streamWriter.WriteLine(Stage.transform.childCount);

            for (int i = 0; i < Stage.transform.childCount; i++)
            {
                Transform game = Stage.transform.GetChild(i);

                string str = $"sprite {game.position.x} {game.position.y} " +
                             $"{game.rotation.eulerAngles.x} {game.rotation.eulerAngles.y} {game.rotation.eulerAngles.z} " +
                             $"{game.localScale.x} {game.localScale.y}";

                streamWriter.WriteLine(str);
            }

            if(BGImage.transform.GetChild(0))
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
