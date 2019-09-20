using System;
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

    public Collider2D[] pegColliders;

    void FixedUpdate()
    {
        if (FindObjectOfType<StrikeController>().struckOut == false)
        {
            SpinTheWheel();
            SlowDownTheWheel();
        }
    }

    private void SpinTheWheel()
    {
        if (wheelState == WheelState.SPIN)
        {
            for (int i = 0; i < pegColliders.Length; i++)
            {
                pegColliders[i].enabled = true;
            }
            if (spinSpeed >= maxSpinSpeed)
            {
                spinSpeed -= Time.deltaTime * spinIncreaseMultiplier;
            }
            transform.Rotate((transform.forward * spinSpeed));
            reducedSpeed = spinSpeed;
        }
    }

    public void RotateWheelToNextSection()
    {
        print("Rotate again");
        wheelState = WheelState.SPIN;
        spinSpeed -= 1f;
        wheelState = WheelState.SLOW_DOWN;
        // FindObjectOfType<WheelFlag>().SendScore();
        // transform.Rotate(new Vector3(0, 0, -10f) * Time.deltaTime);
    }

    private void SlowDownTheWheel()
    {
        if (wheelState == WheelState.SLOW_DOWN)
        {
            print("Slowing down");
            spinSpeed = -1;
            if (reducedSpeed <= 0)
            {
                reducedSpeed += Time.deltaTime * reductionSpeed;
                transform.Rotate((transform.forward * reducedSpeed));
            }
            else
            {
                wheelState = WheelState.STILL;
                reducedSpeed = spinSpeed;

                FindObjectOfType<WheelFlag>().SendScore();
                FindObjectOfType<WheelFlag>().ResetValues();
                if (FindObjectOfType<VelocityMeter>() != null)
                    FindObjectOfType<VelocityMeter>().RestartVelocityMeter();
            }

            if (reducedSpeed >= -5)
            {
                StartCoroutine(DisablePegCollision());
            }
        }
    }

    private IEnumerator DisablePegCollision()
    {
        yield return new WaitForSeconds(2.5f);
        for (int i = 0; i < pegColliders.Length; i++)
        {
            pegColliders[i].enabled = false;
        }
    }

    public void ResetWheel()
    {
        spinSpeed = -1;
        wheelState = WheelState.STILL;
    }

}
