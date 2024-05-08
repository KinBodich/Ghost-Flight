using UnityEngine;
using UnityEngine.UIElements;

public class RocketsUpgradesManager : MonoBehaviour, IDataPersistence // інтерфейс для зберігання даних
{
    private UIDocument _UIDoc;
    [SerializeField] private UIDocument _mainUpgradesUIDoc;
    private Button _backButton, _launchDelayButtonUp, _launchDelayButtonDown, _rocketsAmountButtonUp, _rocketsAmountButtonDown, 
        _rocketSpeedButtonUp, _rocketSpeedButtonDown, _rocketReloadTimeButtonUp, _rocketReloadTimeButtonDown;
    private Label _launchDelayLabel, _rocketsAmountLabel, _rocketSpeedLabel, _rocketReloadTimeLabel;

    private VisualElement _thisUpgradesPanel;

    private void Awake()
    {
        _UIDoc = GetComponent<UIDocument>();
        _thisUpgradesPanel = _UIDoc.rootVisualElement.Q<VisualElement>("Upgrades");

        _backButton = _UIDoc.rootVisualElement.Q<Button>("BackButton");
        _backButton.clicked += OnBackButtonClicked;

        _launchDelayButtonUp = _UIDoc.rootVisualElement.Q<Button>("LaunchDelayButtonUpgrade");
        _launchDelayButtonUp.clicked += () => OnLaunchDelayButtonClicked(-0.1f);
        _launchDelayButtonDown = _UIDoc.rootVisualElement.Q<Button>("LaunchDelayButtonDowngrade");
        _launchDelayButtonDown.clicked += () => OnLaunchDelayButtonClicked(0.1f);
        _launchDelayLabel = _UIDoc.rootVisualElement.Q<Label>("LaunchDelayLabel");

        _rocketsAmountButtonUp = _UIDoc.rootVisualElement.Q<Button>("RocketsAmountButtonUpgrade");
        _rocketsAmountButtonUp.clicked += () => OnRocketsAmountClicked(1);
        _rocketsAmountButtonDown = _UIDoc.rootVisualElement.Q<Button>("RocketsAmountButtonDowngrade");
        _rocketsAmountButtonDown.clicked += () => OnRocketsAmountClicked(-1);
        _rocketsAmountLabel = _UIDoc.rootVisualElement.Q<Label>("RocketsAmountLabel");

        _rocketSpeedButtonUp = _UIDoc.rootVisualElement.Q<Button>("RocketSpeedButtonUpgrade");
        _rocketSpeedButtonUp.clicked += () => OnRocketSpeedButtonClicked(1);
        _rocketSpeedButtonDown = _UIDoc.rootVisualElement.Q<Button>("RocketSpeedButtonDowngrade");
        _rocketSpeedButtonDown.clicked += () => OnRocketSpeedButtonClicked(-1);
        _rocketSpeedLabel = _UIDoc.rootVisualElement.Q<Label>("RocketSpeedLabel");

        _rocketReloadTimeButtonUp = _UIDoc.rootVisualElement.Q<Button>("ReloadTimeButtonUpgrade");
        _rocketReloadTimeButtonUp.clicked += () => OnRocketReloadTimeButtonClicked(-0.5f);
        _rocketReloadTimeButtonDown = _UIDoc.rootVisualElement.Q<Button>("ReloadTimeButtonDowngrade");
        _rocketReloadTimeButtonDown.clicked += () => OnRocketReloadTimeButtonClicked(0.5f);
        _rocketReloadTimeLabel = _UIDoc.rootVisualElement.Q<Label>("ReloadTimeLabel");
    }

    private void Start()
    {
        _thisUpgradesPanel.visible = false;
        _launchDelayLabel.text = $"Launch Delay: {PlayerRocketLaunch.LaunchDelay}";
        _rocketsAmountLabel.text = $"Rockets Amount: {PlayerRocketLaunch.MissileCount}";
        _rocketSpeedLabel.text = $"Rocket Speed: {(Rocket.SpeedIncrement + PlayerMovement.IdleSpeed) * 21}";
        _rocketReloadTimeLabel.text = $"Reload Time: {PlayerRocketLaunch.ReloadTime}";
    }

    private void OnLaunchDelayButtonClicked(float i)
    {
        PlayerRocketLaunch.LaunchDelay = Mathf.Round((PlayerRocketLaunch.LaunchDelay + i) * 10.0f) * 0.1f;
        Debug.Log(PlayerRocketLaunch.LaunchDelay);
        _launchDelayLabel.text = $"Launch Delay: {PlayerRocketLaunch.LaunchDelay}";
    }

    private void OnRocketsAmountClicked(int i)
    {
        PlayerRocketLaunch.MissileCount += i;
        Debug.Log(PlayerRocketLaunch.MissileCount);
        _rocketsAmountLabel.text = $"Rockets Amount: {PlayerRocketLaunch.MissileCount}";
    }

    private void OnRocketSpeedButtonClicked(int i)
    {
        Rocket.SpeedIncrement += i;
        Debug.Log(Rocket.SpeedIncrement);
        _rocketSpeedLabel.text = $"Rocket Speed: {(Rocket.SpeedIncrement + PlayerMovement.IdleSpeed) * 21}";
    }

    private void OnRocketReloadTimeButtonClicked(float i)
    {
        PlayerRocketLaunch.ReloadTime = Mathf.Round((PlayerRocketLaunch.ReloadTime + i) * 10.0f) * 0.1f;
        Debug.Log(PlayerRocketLaunch.ReloadTime);
        _rocketReloadTimeLabel.text = $"Reload Time: {PlayerRocketLaunch.ReloadTime}";
    }

    private void OnBackButtonClicked()
    {
        var mainUpgradesPanel = _mainUpgradesUIDoc.rootVisualElement.Q<VisualElement>("Upgrades");
        _thisUpgradesPanel.visible = false;
        mainUpgradesPanel.visible = true;
    }

    public void LoadData(GameData data) // отримання даних
    {
        PlayerRocketLaunch.LaunchDelay = data.PlayerMissileLaunchDelay;
        PlayerRocketLaunch.MissileCount = data.PlayerMissileCount;
        Rocket.SpeedIncrement = data.RocketSpeedIncrement;
        PlayerRocketLaunch.ReloadTime = data.RocketReloadTime;
    }
     
    public void SaveData(GameData data) // записування даних
    {
        data.PlayerMissileLaunchDelay = PlayerRocketLaunch.LaunchDelay;
        data.PlayerMissileCount = PlayerRocketLaunch.MissileCount;
        data.RocketSpeedIncrement = Rocket.SpeedIncrement;
        data.RocketReloadTime = PlayerRocketLaunch.ReloadTime;
    }
}
