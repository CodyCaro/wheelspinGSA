using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{

    private void OnEnable()
    {
        FindObjectOfType<SpinVelocityButton>().button.interactable = true;

    }
}
