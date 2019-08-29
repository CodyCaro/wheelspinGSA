using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinTypeToggle : MonoBehaviour
{
    public GameManager gameManager;
    public Toggle toggle;
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(ChooseSpinType);
    }

    private void ChooseSpinType(bool _isVelocitySpin)
    {
        gameManager.isVelocitySpin = _isVelocitySpin;
    }

    void Update()
    {

    }
}
