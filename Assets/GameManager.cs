using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isVelocitySpin;
    public GameObject velocitySpin;
    public GameObject holdSpinButton;

    public static GameManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (isVelocitySpin)
        {
            velocitySpin.SetActive(true);
            holdSpinButton.SetActive(false);
        }
        else
        {
            velocitySpin.SetActive(false);
            holdSpinButton.SetActive(true);
        }

    }

}
