using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ChooseColor : MonoBehaviour
{
    public SpriteRenderer segmentSprite;
    private TMP_Dropdown dropdown;

    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(ChangeColor);
    }

    private void ChangeColor(int color)
    {
        if (color == 0)
        {
            segmentSprite.color = Color.yellow;
        }
        else if (color == 1)
        {
            segmentSprite.color = Color.red;
        }
        else if (color == 2)
        {
            segmentSprite.color = Color.blue;
        }
        else if (color == 3)
        {
            segmentSprite.color = Color.green;
        }
        else if (color == 4)
        {
            segmentSprite.color = new Color(255, 127, 0, 255);
        }
        else if (color == 5)
        {
            segmentSprite.color = new Color(0, 255, 243, 255);
        }
    }

    void Update()
    {

    }
}
