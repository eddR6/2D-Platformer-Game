using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public Button button;
    public string sceneToLoad;

    private void Start()
    {
        button.onClick.AddListener(ReloadGame);
        Debug.Log("hh");
    }

    private void ReloadGame()
    {
        Debug.Log("GG");
        SceneManager.LoadScene(sceneToLoad);
    }
}
