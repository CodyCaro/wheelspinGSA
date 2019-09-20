using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VelocityMeter : MonoBehaviour
{
    private Slider velocityMeter;

    public float velocitySpeed;

    Coroutine moveUp;
    Coroutine moveDown;

    public bool canMove = false;
    public bool movingUp;

    public float minVal;
    public float maxVal;

    private void Start()
    {
        velocityMeter = GetComponent<Slider>();
    }

    private void Update()
    {
        if (canMove)
        {

            if (velocityMeter.value >= minVal)
            {
                movingUp = true;
                print("Need to move up");

                moveUp = StartCoroutine(MoveMeterUp());
                if (moveDown != null)
                    StopCoroutine(moveDown);
            }
            else if (velocityMeter.value <= maxVal)
            {
                print("Need to move down");
                movingUp = false;
                moveDown = StartCoroutine(MoveMeterDown());
                StopCoroutine(moveUp);
            }
        }
        else
        {
            print("Stopping");
            StopAllCoroutines();
        }
    }

    IEnumerator MoveMeterUp()
    {
        yield return new WaitForSecondsRealtime(.001f);
        velocityMeter.value += -velocitySpeed;

        if (velocityMeter.value >= maxVal && movingUp)
        {
            StartCoroutine(MoveMeterUp());
        }

    }

    IEnumerator MoveMeterDown()
    {
        yield return new WaitForSecondsRealtime(.001f);
        velocityMeter.value += velocitySpeed;

        if (velocityMeter.value <= minVal && movingUp == false)
        {
            StartCoroutine(MoveMeterDown());
        }

    }

    public void RestartVelocityMeter()
    {
        print("Reset Vel Meter");
        if (movingUp == true)
        {
            moveUp = StartCoroutine(MoveMeterUp());
            if (moveDown != null)
                StopCoroutine(moveDown);
        }
        else if (movingUp == false)
        {
            moveDown = StartCoroutine(MoveMeterDown());
            StopCoroutine(moveUp);
        }

    }

    public float GetCurrentVelocity()
    {
        return velocityMeter.value;
    }
}
