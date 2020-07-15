using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int health;
    private GameObject health1, health2, health3;
    void Start()
    {
        health = 3;
        health1 = gameObject.transform.Find("Life_1").gameObject;
        health2= gameObject.transform.Find("Life_2").gameObject;
        health3 = gameObject.transform.Find("Life_3").gameObject;
    }

    
    public void UpdateLives(int h)
    {
        if (h == 2)
        {
            health1.SetActive(false);
        }else if (h == 1)
        {
            health2.SetActive(false);
        }else if (h == 0)
        {
            health3.SetActive(false);
        }
    }

}
