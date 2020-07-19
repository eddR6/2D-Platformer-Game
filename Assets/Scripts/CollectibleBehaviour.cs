using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public int collectiblePoints;
    public ScoreController scoreController;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hh");
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            scoreController.ScoreToAdd(collectiblePoints);
            Destroy(gameObject);
        }
    }
}
