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
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isBeingHeld = true;
        wheel.spinTheWheel = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (wheelFlag.fullCycleMet)
        {
            isBeingHeld = false;
            wheel.spinTheWheel = false;
            wheel.reduceSpeed = true;
        }
        else
        {
            isBeingHeld = false;
            wheel.ResetWheel();
            wheelFlag.ResetValues();
        }
    }
}
