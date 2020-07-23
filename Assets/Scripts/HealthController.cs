using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            health[i-1].GetComponent<Image>().enabled=(i <= h);
        }
    }

}
