using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpinButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Wheel wheel;
    public WheelFlag wheelFlag;
    public bool isBeingHeld;

    private void Start()
    {
        wheel = FindObjectOfType<Wheel>();
        wheelFlag = FindObjectOfType<WheelFlag>();
        wheel.spinSpeed = -100f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBeingHeld = true;
        wheel.wheelState = WheelState.SPIN;
        wheel.spinSpeed = -100f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (wheelFlag.fullCycleMet)
        {
            isBeingHeld = false;
            wheel.wheelState = WheelState.SLOW_DOWN;
        }
        else
        {
            isBeingHeld = false;
            wheel.ResetWheel();
            wheelFlag.ResetValues();
        }
    }
}
