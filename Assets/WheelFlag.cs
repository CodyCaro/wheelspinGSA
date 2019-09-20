using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelFlag : MonoBehaviour
{
    public event Action<int> OnHandleScore;
    public event Action OnHandleStrike;

    public GameObject firstTickObject;
    public WheelSegment currentTickObject;

    public bool fullCycleMet;
    public bool canCountCycle = true;

    public int fullCyclesNeeded = 1;
    public int cycleCounter;
    public float bounceUpAmount;

    public Transform targetRot;

    public bool hitByPeg;

    private void Update()
    {

    }

    public void SendScore()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);


        if (currentTickObject == null)
        {
            FindObjectOfType<Wheel>().RotateWheelToNextSection();
        }

        StartCoroutine(WaitToSendScore());

    }

    IEnumerator WaitToSendScore()
    {
        yield return new WaitForSeconds(.5f);
        if (currentTickObject == null)
        {
            FindObjectOfType<Wheel>().RotateWheelToNextSection();
            yield break;
        }
        if (OnHandleScore != null && currentTickObject.isStrike == false)
        {
            OnHandleScore(currentTickObject.prizeAmount);
            currentTickObject.TriggerChangeToStrike();
        }
        else if (OnHandleStrike != null && currentTickObject.isStrike)
        {
            OnHandleStrike();
        }
    }

    public void ResetValues()
    {
        if (currentTickObject != null)
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

        if (firstTickObject == null)
        {
            firstTickObject = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        currentTickObject = null;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        currentTickObject = other.gameObject.GetComponent<WheelSegment>();

    }
}
