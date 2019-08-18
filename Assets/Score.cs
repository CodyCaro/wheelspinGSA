using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    private WheelFlag wheelFlag;
    private TextMeshProUGUI scoreDisplay;

    private int totalPrizeAmount;

    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
        FindObjectOfType<WheelFlag>().OnHandleScore += AddScore;
    }

    private void AddScore(int prizeAmount)
    {
        totalPrizeAmount += prizeAmount;
        scoreDisplay.text = "$" + totalPrizeAmount.ToString();
    }
}
