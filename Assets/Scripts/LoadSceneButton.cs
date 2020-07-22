using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LoadSceneButton : MonoBehaviour
{
    private Button button;
    public string sceneToLoad;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ReloadGame);
    }

    private void ReloadGame()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        SceneManager.LoadScene(sceneToLoad);
    }
}
