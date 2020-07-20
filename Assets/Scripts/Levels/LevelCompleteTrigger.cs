using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteTrigger : MonoBehaviour
{
    private Scene currentScene;
    public NavigationMenu levelCompleteMenu;
   
    void Start()
    {
        currentScene= SceneManager.GetActiveScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log(currentScene.name);
            LevelManager.Instance.MarkLevelComplete(currentScene);
            levelCompleteMenu.NavigationEnable();
            //Debug.Log("Level Over!");
            //SceneManager.LoadScene(sceneToLoad);
        }
    }
}
