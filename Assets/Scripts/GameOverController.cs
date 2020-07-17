using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button button;
    void Start()
    {
        button.onClick.AddListener(ReloadLevel);
    }

    public void GameOverPopUp()
    {
        gameObject.SetActive(true);
    }

    private void ReloadLevel()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
