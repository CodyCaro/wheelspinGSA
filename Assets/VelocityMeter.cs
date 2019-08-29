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

    public bool canMove = true;
    public bool movingUp;

    private void Start()
    {
        velocityMeter = GetComponent<Slider>();
    }

    private void Update()
    {
        if (canMove)
        {
            if (velocityMeter.value >= -100f)
            {
                movingUp = true;

                moveUp = StartCoroutine(MoveMeterUp());
                if (moveDown != null)
                    StopCoroutine(moveDown);
            }
            else if (velocityMeter.value <= -250f)
            {
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

        if (velocityMeter.value >= -250 && movingUp)
        {
            StartCoroutine(MoveMeterUp());
        }

    }

    IEnumerator MoveMeterDown()
    {
        yield return new WaitForSecondsRealtime(.001f);
        velocityMeter.value += velocitySpeed;

        if (velocityMeter.value <= -100 && movingUp == false)
        {
            StartCoroutine(MoveMeterDown());
        }

    }

    public void RestartVelocityMeter()
    {
        canMove = true;
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
