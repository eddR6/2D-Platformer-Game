using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour
{
    public int collectiblePoints;
    public ScoreController scoreController;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            scoreController.ScoreToAdd(collectiblePoints);
            Destroy(gameObject);
        }    
    }
}
