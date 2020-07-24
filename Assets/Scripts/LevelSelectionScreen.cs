using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MoveAnimation();

    }

    private void MoveAnimation()
    {
        iTween.MoveFrom(this.gameObject, iTween.Hash("position", new Vector3(transform.position.x - 1500.0f, transform.position.y, 0), "time", 0.5f, "easeType", iTween.EaseType.linear));
    }
}
