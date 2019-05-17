using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if(!instance)
            {
                GameObject gameObj = new GameObject("StageManager");
                instance = gameObj.AddComponent<StageManager>();
                DontDestroyOnLoad(gameObj);
            }

            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    public static int StageCount = 200;

    public static int CurrentStage = 1;

    public bool[] HasTutorial = new bool[StageCount + 1];

    public bool[] IsSuccess = new bool[StageCount + 1];

    
    public void LoadData()
    {
        SaveData data = SaveSystem.LoadData();

        for (int i = 1; i <= StageCount; i++)
        {
            HasTutorial[i] = data.HasTutorial[i];
            IsSuccess[i] = data.IsSuccess[i];
        }
    }

    public void SaveStage()
    {
        SaveSystem.SaveStage();
    }
}

[System.Serializable]
public class SaveData
{
    public bool[] HasTutorial = new bool[StageManager.StageCount + 1];
    public bool[] IsSuccess = new bool[StageManager.StageCount + 1];

    public SaveData(StageManager stageManager)
    {
        HasTutorial[1] = false;
        IsSuccess[1] = true;
        for (int i = 2; i <= StageManager.StageCount; i++) 
        {
            HasTutorial[i] = stageManager.HasTutorial[i];
            IsSuccess[i] = stageManager.IsSuccess[i];
        }
    }

    public SaveData() // Default SaveData
    {
        HasTutorial[1] = false;
        IsSuccess[1] = true;
        for (int i = 2; i <= StageManager.StageCount; i++) 
        {
            HasTutorial[i] = false;
            IsSuccess[i] = false;
        }
        IsSuccess[1] = true;
    }
}

public static class SaveSystem
{
    public static void SaveStage()
    {
        StageManager stageManager = StageManager.Instance;

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Stage.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(stageManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/Stage.fun";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();

            return data;
        }
        else
        {
            SaveData data = new SaveData();

            return data;
        }
    }

}