using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject[] health;
    public int MaxHealth()
    {
        return health.Length;
    }
    
    public void UpdateLives(int h)
    {
       for(int i = 1; i <= health.Length; i++)
        {
            health[i-1].SetActive(i <= h);
        }
    }

}
