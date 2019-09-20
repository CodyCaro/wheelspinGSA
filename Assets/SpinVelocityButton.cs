using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinVelocityButton : MonoBehaviour
{
    public Wheel wheel;
    public WheelFlag wheelFlag;
    public Button button;

    public int clickCount;

    private bool firstClick;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SpinWheel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && clickCount == 1)
        {
            clickCount = 0;
            if (wheel.wheelState == WheelState.STILL)
            {
                wheel.spinSpeed = FindObjectOfType<VelocityMeter>().GetCurrentVelocity();
                print(FindObjectOfType<VelocityMeter>().GetCurrentVelocity());
                FindObjectOfType<VelocityMeter>().canMove = false;
                wheel.wheelState = WheelState.SPIN;
                StartCoroutine(SlowWheel());
            }
        }
    }

    public void SpinWheel()
    {
        button.interactable = false;
        if (clickCount == 0)
        {
            if (firstClick == true)
            {
                firstClick = false;
            }
            clickCount = 1;
            FindObjectOfType<VelocityMeter>().canMove = true;


            if (firstClick == false)
            {
                FindObjectOfType<VelocityMeter>().RestartVelocityMeter();
                print("Reset after first click");
            }

        }



    }

    IEnumerator SlowWheel()
    {
        yield return new WaitForSeconds(2f);
        wheel.wheelState = WheelState.SLOW_DOWN;
    }
}
