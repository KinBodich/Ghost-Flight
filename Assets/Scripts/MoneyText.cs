using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    private void Awake()
    {
         
    }

    private void Start()
    {
        MoneySystem.Instance.OnMoneyAmountChange += () => SetText(MoneySystem.Instance.MoneyAmount);
        _text = GetComponent<TextMeshProUGUI>();

        SetText(MoneySystem.Instance.MoneyAmount);
    }

    private void SetText(int text)
    {
        _text.SetText($"{text} $");
    }
}
