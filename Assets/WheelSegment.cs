using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelSegment : MonoBehaviour
{
    public int prizeAmount;
    public TextMeshPro prizeText;

    private RectTransform rectTransform;

    public bool isStrike;

    void Start()
    {
        prizeText = GetComponentInChildren<TextMeshPro>();
        rectTransform = GetComponentInChildren<RectTransform>();
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
        rectTransform.rotation = Quaternion.Euler(0, 0, 0);
        prizeText.fontSize = 45.5f;
        prizeText.color = Color.red;
    }
}
