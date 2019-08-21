using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikeController : MonoBehaviour
{
    private WheelFlag wheelFlag;
    public int strikeCount;
    public Strike[] strikes;

    public bool struckOut;

    void Start()
    {
        wheelFlag = FindObjectOfType<WheelFlag>();
        wheelFlag.OnHandleStrike += HandleStrike;
    }

    private void HandleStrike()
    {
        strikeCount += 1;
        strikes[strikeCount - 1].gameObject.SetActive(true);
    }

}
