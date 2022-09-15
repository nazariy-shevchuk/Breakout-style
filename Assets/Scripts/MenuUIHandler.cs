using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadDetails();
        if (File.Exists(Application.persistentDataPath + "/savefile.json") == true)
        {
            DataManager.Instance.LoadName();
            DataManager.Instance.LoadHighScore();
        }
    }

    public void LoadMainScene()
    {
        DataManager.Instance.SaveName();
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
