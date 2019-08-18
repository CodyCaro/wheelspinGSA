using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WheelState
{
    STILL,
    SPIN,
    SLOW_DOWN
}

public class Wheel : MonoBehaviour
{
    public float maxSpinSpeed;
    public float spinSpeed;
    public float spinIncreaseMultiplier;

    public float reducedSpeed;
    public float reductionSpeed;

    public WheelState wheelState;

    void Update()
    {
        SpinTheWheel();
        SlowDownTheWheel();
    }

    private void SpinTheWheel()
    {
        if (wheelState == WheelState.SPIN)
        {
            if (spinSpeed >= maxSpinSpeed)
            {
                spinSpeed -= Time.deltaTime * spinIncreaseMultiplier;
            }
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            reducedSpeed = spinSpeed;
        }
    }

    private void SlowDownTheWheel()
    {
        if (wheelState == WheelState.SLOW_DOWN)
        {
            spinSpeed = -1;
            if (reducedSpeed <= 0)
            {
                reducedSpeed += Time.deltaTime * reductionSpeed;
                transform.Rotate(0, 0, reducedSpeed * Time.deltaTime);
            }
            else
            {
                wheelState = WheelState.STILL;
                reducedSpeed = spinSpeed;
                FindObjectOfType<WheelFlag>().ResetValues();
            }
        }
    }

    public void ResetWheel()
    {
        spinSpeed = -1;
        wheelState = WheelState.STILL;
    }

}
