using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static SaveData saveData;
    private void Awake()
    {
        LoadData();
    }

    public void SaveGame()
    {
        var data = JsonUtility.ToJson(saveData);
        Debug.Log(data);
        PlayerPrefs.SetString("GameData", data);
    }

    public void LoadData()
    {
        var data = PlayerPrefs.GetString("GameData");
        saveData = JsonUtility.FromJson<SaveData>(data);
    }
}
