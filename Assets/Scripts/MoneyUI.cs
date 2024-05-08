using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoneyUI : MonoBehaviour
{
    private UIDocument _UIDocument;
    private Label _moneyLabel;

    private void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        _moneyLabel = _UIDocument.rootVisualElement.Q<Label>("MoneyLabel");
    }

    private void Start()
    {
        UpgradeButtonManager.OnMoneyChange += MenuSystemOnMoneyAmountChange;
    }

    private void MenuSystemOnMoneyAmountChange()
    {
        _moneyLabel.text = $"{UpgradeButtonManager.MoneyAmount} $";
    }
}
