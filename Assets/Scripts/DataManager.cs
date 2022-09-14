using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName = "";
    public int highScore;
    public string highScorePlayer = "";

    private void Awake()
    {
        if(Instance != null)
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
}
