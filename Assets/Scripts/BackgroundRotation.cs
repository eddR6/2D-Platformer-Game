using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GUI;

public class BackgroundRotation : MonoBehaviour
{
    public Transform player;
    void Awake()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, 10);
    }
}
