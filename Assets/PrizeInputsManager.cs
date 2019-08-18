using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeInputsManager : MonoBehaviour
{
    public int[] prizes;

    void Start()
    {
        LoadPrizes();
    }

    void Update()
    {

    }

    public void LoadPrizes()
    {
        for (int i = 0; i < prizes.Length; i++)
        {
            if (PlayerPrefs.HasKey("Prize" + i))
            {
                prizes[i] = PlayerPrefs.GetInt("Prize" + i);
            }
        }
    }


    public void SavePrizes(int index, int prizeAmount)
    {
        prizes[index] = prizeAmount;

        PlayerPrefs.SetInt("Prize" + index, prizeAmount);
    }
}
