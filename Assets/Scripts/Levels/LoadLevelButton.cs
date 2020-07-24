using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LoadLevelButton : MonoBehaviour
{
    private Button button;
    public string levelName;
    private string levelDisplayName;
    public Text levelText;

    private void Start()
    {
        //levelText = gameObject.GetComponent<Text>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
        levelDisplayName = LevelManager.Instance.LevelDisplayName(levelName);
        DisplayButtonText();
    }
    private void DisplayButtonText()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                levelText.text = "Locked";
                break;
            case LevelStatus.Unlocked:
                levelText.text = levelDisplayName;
                break;
            case LevelStatus.Completed:
                levelText.text = levelDisplayName;
                break;

        }
    }

    private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.Play(Sounds.LevelLocked);
                Debug.Log("Level Locked");
                break;
            case LevelStatus.Unlocked:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                break;
            case LevelStatus.Completed:
                SoundManager.Instance.Play(Sounds.ButtonClick);
                SceneManager.LoadScene(levelName);
                break;

        }
    }
}

