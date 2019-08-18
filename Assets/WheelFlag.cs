using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFlag : MonoBehaviour
{
    public GameObject firstTickObject;

    public bool fullCycleMet;

    public int fullCyclesNeeded = 1;
    public int cycleCounter;

    private void Start()
    {

    }

    public void ResetValues()
    {
        firstTickObject = null;
        cycleCounter = 0;
        fullCycleMet = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == firstTickObject)
        {
            cycleCounter += 1;

            if (cycleCounter >= fullCyclesNeeded)
            {
                fullCycleMet = true;
            }
        }


        if (firstTickObject == null)
        {
            firstTickObject = other.gameObject;
        }
    }
}
