using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLastScene()
    {
        string lastSceneName = PlayerPrefs.GetString("LastScene");
        SceneManager.LoadScene(lastSceneName);
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
