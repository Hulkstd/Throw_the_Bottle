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

    public RectTransform Content;
    public static int ContentsCount;

    private List<Button> Buttons;
    private List<RectTransform> Contents;

    private void Awake()
    {
        Buttons = new List<Button>();
        Contents = new List<RectTransform>();
        int StageNumber = 1;
        int StageMax = Resources.LoadAll("StageMap").Length;
        RectTransform PivotObj;

        int buf = StageMax;
        int Count = 0;

        while (buf > 0)
        {
            Count++;
            buf -= 28;
        }

        for (int j = 0; j < Count; ++j)
        {
            RectTransform transform = new GameObject().AddComponent<RectTransform>();
            transform.SetParent(Content);
            Contents.Add(transform);
            if (j > 0)
                Contents[j].anchoredPosition = Contents[j - 1].anchoredPosition + new Vector2(1100, 0);
            else
                Contents[j].anchoredPosition = new Vector2(-1667, 0);
            Contents[j].sizeDelta = new Vector2(1100, 1800);
            Contents[j].name = "Content";
            PivotObj = new GameObject().AddComponent<RectTransform>();
            PivotObj.SetParent(Contents[j]);
            PivotObj.anchoredPosition = new Vector2(-550, 900);
            PivotObj.name = "PivotObj";
        }

        ContentsCount = Contents.Count;

        StageManager manager = StageManager.Instance;
        manager.LoadData();

        // button Instantiate

        Vector2 Pivot;
        float[] arr = { -350, -125, 125, 350 };
        bool IsOut = false;

        for (int j = 0; j < Contents.Count; ++j)
        {
            Pivot = Contents[j].GetChild(0).localPosition;
            for (float Height = Pivot.y - 150; Height > Contents[j].anchoredPosition.y - 900; Height -= ButtonSize.y + Merge.y)
            {
                for (int k = 0; k < 4; ++k)
                {
                    if (StageNumber > StageMax)
                    {
                        IsOut = true;
                        break;
                    }

                    Button button = Instantiate(StageButtonPR, Contents[j], false);
                    button.onClick.AddListener(delegate () { stageSelector.EnterStage(button.gameObject.transform.GetChild(0).GetComponent<Text>()); });
                    button.onClick.AddListener(delegate () { Buttons.ForEach(b => { b.interactable = false; }); });
                    button.transform.GetChild(0).GetComponent<Text>().text = StageNumber.ToString();
                    button.interactable = manager.IsSuccess[StageNumber];
                    button.targetGraphic = button.transform.GetChild(0).GetComponent<Text>();
                    button.GetComponent<RectTransform>().sizeDelta = ButtonSize;
                    button.name = "Button" + StageNumber.ToString();
                    button.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(arr[k], Height);

                    StageNumber++;

                    Buttons.Add(button);
                }

                if (IsOut)
                {
                    IsOut = false;
                    break;
                }
            }

        }

    }
}
