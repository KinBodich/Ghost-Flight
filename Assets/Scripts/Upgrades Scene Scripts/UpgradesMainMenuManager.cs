using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UpgradesMainMenuManager : MonoBehaviour
{
    private UIDocument _UIDoc;  // документ з дизайном
    [SerializeField] private UIDocument _planeCharacteristicsUIDoc, _rocketsCharacteristicsUIDoc;  // документи з дизайном характеристик літака та озброєння
    private Button _planeCharacteristicsButton, _rocketsCharacteristicsButton, _backButton; // елементи кнопок

    

    private VisualElement _thisUpgradesPanel; // для відображення у сцені

    private void Awake()
    {
        _planeCharacteristicsUIDoc.gameObject.SetActive(true); 
        _rocketsCharacteristicsUIDoc.gameObject.SetActive(true);
        _UIDoc = GetComponent<UIDocument>(); // отримання об'єкту документа
        _thisUpgradesPanel = _UIDoc.rootVisualElement.Q<VisualElement>("Upgrades"); // отримання об'єкту для відображення

        _planeCharacteristicsButton = _UIDoc.rootVisualElement.Q<Button>("PlaneCharacteristicsButton"); // отримання об'єкту кнопки
        var planeCharacteristicsPanel = _planeCharacteristicsUIDoc.rootVisualElement.Q<VisualElement>("Upgrades"); // отримання об'єкту для відображення
        planeCharacteristicsPanel.visible = false;
        _planeCharacteristicsButton.clicked += () => OnUpgradesButtonClicked(planeCharacteristicsPanel); // підпис на подію

        _rocketsCharacteristicsButton = _UIDoc.rootVisualElement.Q<Button>("RocketsCharacteristicsButton");
        var rocketsCharacteristicsPanel = _rocketsCharacteristicsUIDoc.rootVisualElement.Q<VisualElement>("Upgrades");
        _rocketsCharacteristicsButton.clicked += () => OnUpgradesButtonClicked(rocketsCharacteristicsPanel);

        _backButton = _UIDoc.rootVisualElement.Q<Button>("BackButton");
        _backButton.clicked += OnBackButtonClicked;
    }

    private void OnUpgradesButtonClicked(VisualElement otherPanel) // метод для відображення панелей
    {
        _thisUpgradesPanel.visible = false;
        otherPanel.visible = true;
    }

    private void OnBackButtonClicked() // вийти в меню характеристик
    {
        SceneManager.LoadScene(0);
    }
}
