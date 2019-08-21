using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelSegment : MonoBehaviour
{
    public int prizeAmount;
    public TextMeshPro prizeText;

    public bool isStrike;

    void Start()
    {
        prizeText = GetComponentInChildren<TextMeshPro>();
    }


    public void SetPrizeAmount(int _prizeAmount)
    {
        prizeAmount = _prizeAmount;
        prizeText.text = "$" + prizeAmount.ToString();
    }

    public void TriggerChangeToStrike()
    {
        StartCoroutine(ChangeToStrike());
    }

    IEnumerator ChangeToStrike()
    {
        yield return new WaitForSeconds(.5f);
        isStrike = true;
        prizeText.text = "X";
        prizeText.fontSize = 45.5f;
        prizeText.color = Color.red;
    }
}
