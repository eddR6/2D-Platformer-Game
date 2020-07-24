using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class QuitButton : MonoBehaviour
{
    private Button button;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    private void QuitGame()
    {
        //Application.Quit()
        EditorApplication.isPlaying = false;
    }
}
