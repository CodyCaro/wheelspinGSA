using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFlag : MonoBehaviour
{
    public event Action<int> OnHandleScore;

    public GameObject firstTickObject;
    public WheelSegment currentTickObject;

    public bool fullCycleMet;
    public bool canCountCycle = true;

    public int fullCyclesNeeded = 1;
    public int cycleCounter;

    private void Start()
    {

    }

    public void SendScore()
    {
        if (OnHandleScore != null)
        {
            OnHandleScore(currentTickObject.prizeAmount);
        }
    }

    public void ResetValues()
    {
        firstTickObject = currentTickObject.gameObject;
        cycleCounter = 0;
        fullCycleMet = false;
        canCountCycle = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == firstTickObject)
        {
            if (canCountCycle == true)
            {
                cycleCounter += 1;
                canCountCycle = false;
            }

            if (cycleCounter >= fullCyclesNeeded)
            {
                fullCycleMet = true;
            }
        }

        if (other.gameObject != firstTickObject)
        {
            canCountCycle = true;
        }

        currentTickObject = other.gameObject.GetComponent<WheelSegment>();


        if (firstTickObject == null)
        {
            firstTickObject = other.gameObject;
        }
    }
}
