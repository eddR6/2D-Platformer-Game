using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class EnablePopUp : MonoBehaviour
{
    private Button button;
    public GameObject popUp;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PopUp);
    }

    
    void PopUp()
    {
        popUp.SetActive(true);
    }
}
