using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelSegment : MonoBehaviour
{
    public int prizeAmount;
    public TextMeshPro prizeText;

    void Start()
    {
        prizeText = GetComponentInChildren<TextMeshPro>();
    }

    void Update()
    {

    }

    public void SetPrizeAmount(int _prizeAmount)
    {
        prizeAmount = _prizeAmount;
        prizeText.text = "$" + prizeAmount.ToString();
    }
}
