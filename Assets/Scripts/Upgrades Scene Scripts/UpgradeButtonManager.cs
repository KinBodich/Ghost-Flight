using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UpgradeButtonManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] private UpgradeButtonSO _upgradeButtonInfo;

    [SerializeField] private UIDocument _UIDocument;
    private Button _upgradeButton;
    private Label _upgradePriceLabel;
    private List<VisualElement> _upgradeLevels;
    private byte _currentLevel;
    private int _upgradePrice;
    public static int MoneyAmount { get; private set; }
    private float _upgrade;
    [SerializeField] UpgradeType _planeUpgradeType;

    public static event Action OnMoneyChange;

    private void Awake()
    {
        _upgradeButton = _UIDocument.rootVisualElement.Q<Button>($"{_upgradeButtonInfo.UpgradeName}UpgradeButton");
        _upgradePriceLabel = _UIDocument.rootVisualElement.Q<Label>($"{_upgradeButtonInfo.UpgradeName}UpgradePrice");
        _upgradeLevels = _UIDocument.rootVisualElement.Query<VisualElement>($"{_upgradeButtonInfo.UpgradeName}Level").ToList();
    }

    private void Start()
    {
        _upgradeButton.clicked += UpgradeButtonClicked;
        _upgradePriceLabel.text = $"{_upgradePrice}";
        FillLevelBars(_upgradeLevels, _currentLevel);
        Debug.Log(_upgradeLevels.Count);
    }

    private void UpgradeButtonClicked()
    {
        if (_currentLevel >= 6 || MoneyAmount < _upgradePrice)
            return;

        _currentLevel++;

        MoneyAmount -= _upgradePrice;
        _upgradePrice *= 2;
        _upgrade += _upgradeButtonInfo.UpgradeIncrement;

        _upgradePriceLabel.text = $"{_upgradePrice} $";
        FillLevelBars(_upgradeLevels, _currentLevel);
        OnMoneyChange?.Invoke();
        Debug.Log($"{_upgradeButtonInfo.UpgradeName} clicked");
    }

    private void FillLevelBars(List<VisualElement> levels, byte upgradedLevels)
    {
        for (byte lvl = 0; lvl < upgradedLevels; lvl++)
        {
            levels[lvl].style.backgroundColor = Color.yellow;
        }
    }

    public void LoadData(GameData data)
    {
        MoneyAmount = data.MoneyAmount;
        UpgradeTypeManager.LoadUpgradeType(data, _planeUpgradeType, ref _upgrade, ref _currentLevel, ref _upgradePrice);
    }

    public void SaveData(GameData data)
    {
        data.MoneyAmount = MoneyAmount;
        UpgradeTypeManager.SaveUpgradeType(data, _planeUpgradeType, ref _upgrade, ref _currentLevel, ref _upgradePrice);
    }
}