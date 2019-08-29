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
        wheelFlag = FindObjectOfType<WheelFlag>();
        scoreDisplay = GetComponent<TextMeshProUGUI>();
        wheelFlag.OnHandleScore += AddScore;
    }

    private void AddScore(int prizeAmount)
    {
        totalPrizeAmount += prizeAmount;
        scoreDisplay.text = "$" + totalPrizeAmount.ToString();
    }

    private void OnDestroy()
    {
        wheelFlag.OnHandleScore -= AddScore;
    }
    private void OnDisable()
    {
        wheelFlag.OnHandleScore -= AddScore;
    }

}
