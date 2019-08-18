using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float maxSpinSpeed;
    public float spinSpeed;
    public float spinIncreaseMultiplier;

    public float reducedSpeed;
    public float reductionSpeed;

    //Enum?
    public bool spinTheWheel;
    public bool reduceSpeed;

    void Start()
    {

    }

    void Update()
    {
        if (spinTheWheel)
        {
            if (spinSpeed >= maxSpinSpeed)
            {
                spinSpeed -= Time.deltaTime * spinIncreaseMultiplier;
            }
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
            reducedSpeed = spinSpeed;
        }

        if (reduceSpeed)
        {
            spinSpeed = -1;
            if (reducedSpeed <= 0)
            {
                reducedSpeed += Time.deltaTime * reductionSpeed;
                transform.Rotate(0, 0, reducedSpeed * Time.deltaTime);
            }
            else
            {
                reduceSpeed = false;
                reducedSpeed = spinSpeed;
                FindObjectOfType<WheelFlag>().ResetValues();
            }
        }
    }

    public void ResetWheel()
    {
        spinSpeed = -1;
        spinTheWheel = false;
    }

}
