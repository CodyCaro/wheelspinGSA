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

    public bool movingUp;

    private void Start()
    {
        velocityMeter = GetComponent<Slider>();
    }

    private void Update()
    {
        if (velocityMeter.value >= -1f)
        {
            movingUp = true;

            print("Please move up");
            // velocityMeter.value -= velocitySpeed * Time.deltaTime;
            moveUp = StartCoroutine(MoveMeterUp());
            if (moveDown != null)
                StopCoroutine(moveDown);
        }
        else if (velocityMeter.value <= -250f)
        {
            movingUp = false;
            print("Please move down");
            moveDown = StartCoroutine(MoveMeterDown());
            StopCoroutine(moveUp);
            // StartCoroutine(MoveMeterDown());
        }
    }

    IEnumerator MoveMeterUp()
    {
        yield return new WaitForSecondsRealtime(.001f);
        print(velocityMeter.value + " move up");
        velocityMeter.value += -velocitySpeed;

        if (velocityMeter.value >= -250 && movingUp)
        {
            StartCoroutine(MoveMeterUp());
        }

    }

    IEnumerator MoveMeterDown()
    {
        yield return new WaitForSecondsRealtime(.001f);
        print(velocityMeter.value + " move down");
        velocityMeter.value += velocitySpeed;

        if (velocityMeter.value <= -1 && movingUp == false)
        {
            StartCoroutine(MoveMeterDown());
        }

    }
}
