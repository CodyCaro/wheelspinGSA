using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinVelocityButton : MonoBehaviour
{
    public Wheel wheel;
    public WheelFlag wheelFlag;
    public Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SpinWheel);
    }

    public void SpinWheel()
    {
        wheel.spinSpeed = FindObjectOfType<VelocityMeter>().GetCurrentVelocity();
        FindObjectOfType<VelocityMeter>().canMove = false;
        wheel.wheelState = WheelState.SPIN;
        StartCoroutine(SlowWheel());
    }

    IEnumerator SlowWheel()
    {
        yield return new WaitForSeconds(2f);
        wheel.wheelState = WheelState.SLOW_DOWN;
    }
}
