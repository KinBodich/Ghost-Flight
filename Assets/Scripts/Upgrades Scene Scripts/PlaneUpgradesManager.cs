using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PlaneUpgradesManager : MonoBehaviour, IDataPersistence
{
    private UIDocument _UIDocument;
    [SerializeField] private UIDocument _mainUpgradesUIDoc;
    [SerializeField] private string _upgradeName;
    private Button _upgradeButton;
    private Label _upgradeLabel;
    private List<VisualElement> _upgradeLevels;
    private byte _currentLevel;
    private int _upgradePrice;
    private int _moneyAmount;
    private float _toUpgrade;



































    private Button _backButton, _maxSpeedButton, _engineButton, _breakesButton, _eleronsButton;
    private Label _moneyAmountLabel, _maxSpeedUpgradePriceLabel, _engineUpgradePriceLabel;
    private VisualElement _thisUpgradesPanel;

    private List<VisualElement> MaxSpeedLevels, EngineLevels;

    private byte _maxSpeedLevel = 0, _engineLevel;
    private int _maxSpeedUpgradePrice = 100, _engineUpgradePrice;
    private int MoneyAmount;
    private float _maxSpeed;

    private void Awake()
    {
        _UIDocument = GetComponent<UIDocument>();
        _thisUpgradesPanel = _UIDocument.rootVisualElement.Q<VisualElement>("Upgrades");

        _moneyAmountLabel = _UIDocument.rootVisualElement.Q<Label>("MoneyLabel");

        _backButton = _UIDocument.rootVisualElement.Q<Button>("ExitButton");
        _backButton.clicked += OnBackButtonClicked;

        _maxSpeedButton = _UIDocument.rootVisualElement.Q<Button>("MaxSpeedUpgradeButton");
        //_maxSpeedButton.clicked += () => OnMaxSpeedButtonClicked(5);
        MaxSpeedLevels = _UIDocument.rootVisualElement.Query<VisualElement>("MaxSpeedLevel").ToList();
        _maxSpeedUpgradePriceLabel = _UIDocument.rootVisualElement.Q<Label>("MaxSpeedUpgradePrice");

        _engineButton = _UIDocument.rootVisualElement.Q<Button>("EnginePowerUpgradeButton");
        //_engineButton.clicked += () => OnEngineButtonClicked(1);
        EngineLevels = _UIDocument.rootVisualElement.Query<VisualElement>("EnginePowerLevel").ToList();
        _engineUpgradePriceLabel = _UIDocument.rootVisualElement.Q<Label>("EnginePowerUpgradePrice");

        _breakesButton = _UIDocument.rootVisualElement.Q<Button>("BrakesUpgradeButton");
        //_breakesButton.clicked += () => OnBrakesButtonClicked(1);

        _eleronsButton = _UIDocument.rootVisualElement.Q<Button>("EleronsUpgradeButton");
        //_eleronsButton.clicked += () => OnEleronsButtonClicked(1);
    }

    private void Start()
    {

        _moneyAmountLabel.text = $"{MoneyAmount} $";
        _maxSpeedUpgradePriceLabel.text = $"{_maxSpeedUpgradePrice}";
        //FillLevelBars(MaxSpeedLevels, _maxSpeedLevel);
    }

    private void OnMaxSpeedButtonClicked(int s)
    {
        if (_maxSpeedLevel >= 6 || MoneyAmount < _maxSpeedUpgradePrice)
            return;

        _maxSpeedLevel++;

        FillLevelBars(MaxSpeedLevels, _maxSpeedLevel);

        MoneyAmount -= _maxSpeedUpgradePrice;
        _maxSpeedUpgradePrice *= 2;
        _maxSpeed += s;

        _maxSpeedUpgradePriceLabel.text = $"{_maxSpeedUpgradePrice} $";
        _moneyAmountLabel.text = $"{MoneyAmount} $";

        Debug.Log(_maxSpeed);
    }

    private void FillLevelBars(List<VisualElement> levels, byte upgradedLevels)
    {
        for (byte lvl = 0; lvl < upgradedLevels; lvl++)
        {
            levels[lvl].style.backgroundColor = Color.black;
        }
    }

    private void OnEngineButtonClicked(int s)
    {
        PlayerMovement.Acceleration += s;
        Debug.Log(PlayerMovement.Acceleration);
    }

    private void OnBrakesButtonClicked(int s)
    {
        PlayerMovement.Deceleration += s;
        Debug.Log(PlayerMovement.Deceleration);
    }

    private void OnEleronsButtonClicked(int s)
    {
        PlayerMovement.RotationSpeed += s;
        Debug.Log(PlayerMovement.RotationSpeed);
    }

    private void OnBackButtonClicked()
    {
        var mainUpgradesPanel = _mainUpgradesUIDoc.rootVisualElement.Q<VisualElement>("Upgrades");
        _thisUpgradesPanel.visible = false;
        mainUpgradesPanel.visible = true;
    }

    public void LoadData(GameData data)  // отримання даних
    {
        _maxSpeed = data.PlayerMaxSpeed;
        PlayerMovement.Acceleration = data.PlayerAcceleration;
        PlayerMovement.Deceleration = data.PlayerDeceleration;
        PlayerMovement.RotationSpeed = data.PlayerRotationSpeed;
        _maxSpeedLevel = data.PlayerMaxSpeedLevel;
        _maxSpeedUpgradePrice = data.PlayerMaxSpeedUpgradePrice;
        MoneyAmount = data.MoneyAmount;
    }

    public void SaveData(GameData data) // записування даних
    {
        data.PlayerMaxSpeed = _maxSpeed;
        data.PlayerAcceleration = PlayerMovement.Acceleration;
        data.PlayerDeceleration = PlayerMovement.Deceleration;
        data.PlayerRotationSpeed = PlayerMovement.RotationSpeed;
        data.PlayerMaxSpeedLevel = _maxSpeedLevel;
        data.PlayerMaxSpeedUpgradePrice = _maxSpeedUpgradePrice;
        data.MoneyAmount = MoneyAmount;
    }
}
