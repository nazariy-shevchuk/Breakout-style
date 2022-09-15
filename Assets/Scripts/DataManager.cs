using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName = "";
    public int highScore;
    public string highScorePlayer = "";

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveName()
    {
        playerName = GameObject.Find("Name Input").GetComponent<TMP_InputField>().text;
    }

    public void LoadName()
    {
        GameObject.Find("Name Input").GetComponent<TMP_InputField>().text = playerName;
    }

    public void LoadHighScore()
    {
        GameObject.Find("High Score").GetComponent<TextMeshProUGUI>().text = highScorePlayer + " currently has the high score: " + highScore;
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highScorePlayer;
    }

    public void SaveDetails()
    {
        SaveData data = new SaveData();
        
        data.highScore = highScore;
        data.highScorePlayer = highScorePlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDetails()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
        }
    }
}
