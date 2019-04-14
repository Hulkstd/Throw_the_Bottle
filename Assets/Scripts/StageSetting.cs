using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSetting : MonoBehaviour
{
    public StageSelector stageSelector;
    public Button StageButtonPR;
    [Tooltip("This Vector2 is Button's width and height")]
    public Vector2 ButtonSize;
    [Tooltip("This position is on Left Top")]
    public Vector2 BasePosition;
    [Tooltip("This Vector2 is Merge in width and height")]
    public Vector2 Merge;
    [Tooltip("This Vector2 is Content's width and height")]
    public Vector2 ContentSize;

    public Transform Content;

    private List<Button> Buttons;

    private void Awake()
    {
        Vector2 Position = BasePosition;
        Buttons = new List<Button>();
        int i = 1;

        StageManager manager = StageManager.Instance;
        manager.LoadData();

        for (float Width = 0; Width < ContentSize.x - Merge.x; Width += Merge.x + ButtonSize.x)
        {
            for (float Height = 0; Height < ContentSize.y - Merge.y; Height += Merge.y + ButtonSize.y)
            {
                Button button = Instantiate(StageButtonPR, Content, false);
                button.onClick.AddListener(delegate () { stageSelector.EnterStage(button.gameObject.transform.GetChild(0).GetComponent<Text>()); });
                button.onClick.AddListener(delegate () { Buttons.ForEach(b => { b.interactable = false; } ); });
                button.gameObject.transform.GetChild(0).GetComponent<Text>().text = i.ToString();
              //  button.interactable = manager.IsSuccess[i];
                
                i++;

                //Debug.Log(Width + " " + Height);

                button.gameObject.GetComponent<RectTransform>().localPosition -= new Vector3(-Width, Height);

                Buttons.Add(button);
            }
        }
    }
}
