using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrizeInputField : MonoBehaviour
{
    public PrizeInputsManager prizeInputsManager;

    public TMP_InputField inputField;
    public WheelSegment wheelSegment;

    public int savedPrizeAmount;

    public int fieldNumber;

    void Start()
    {
        prizeInputsManager = GetComponentInParent<PrizeInputsManager>();

        inputField = GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(SetPrizeAmount);

        LoadPreviousPrize();
    }

    public void LoadPreviousPrize()
    {
        if (PlayerPrefs.HasKey("Prize" + fieldNumber))
        {
            inputField.placeholder.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Prize" + fieldNumber).ToString();
            savedPrizeAmount = PlayerPrefs.GetInt("Prize" + fieldNumber);
            SetPrizeAmount(savedPrizeAmount.ToString());
        }
    }

    void SetPrizeAmount(string input)
    {
        int amountInt = int.Parse(input);
        prizeInputsManager.SavePrizes(fieldNumber, amountInt);
        wheelSegment.SetPrizeAmount(amountInt);
    }
}
