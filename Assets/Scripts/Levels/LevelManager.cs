using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }
    public string Level1;
    public int totalLevels;

    private void Awake()
    {
         if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (Instance.GetLevelStatus(Level1) == LevelStatus.Locked)
        {
           Instance.SetLevelStatus(Level1, LevelStatus.Unlocked);
        }
    }
    public void MarkLevelComplete(Scene currentScene)
    {
        Instance.SetLevelStatus(currentScene.name, LevelStatus.Completed);
        UnlockNextLevel(currentScene);
    }

    private void UnlockNextLevel(Scene currentScene)
    {
        int nextSceneIndex = currentScene.buildIndex + 1;
        if (nextSceneIndex <= totalLevels)
        {
            string nextLevelPath = SceneUtility.GetScenePathByBuildIndex(nextSceneIndex);
            //getting level name from path
            int slash = nextLevelPath.LastIndexOf('/');
            int dot = nextLevelPath.LastIndexOf('.');
            string nextLevelName = nextLevelPath.Substring(slash + 1, dot - slash - 1);
            //Debug.Log(nextLevelName);
            Instance.SetLevelStatus(nextLevelName, LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus status=(LevelStatus)PlayerPrefs.GetInt(level, 0);
        return status;
    }
    public void SetLevelStatus(string level,LevelStatus status)
    {
        PlayerPrefs.SetInt(level, (int)status);
    }
   
}
