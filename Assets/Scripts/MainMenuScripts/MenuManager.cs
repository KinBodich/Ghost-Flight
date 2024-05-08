using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _UIDoc; // документ з дизайном
    private Button _playButton, _upgradesButton, _settingsButton, _exitButton; // елементи кнопок

    /*private void Awake()
    {
        _UIDoc = GetComponent<UIDocument>(); // отримання об'єкту документа
        _playButton = _UIDoc.rootVisualElement.Q<Button>("PlayButton"); // отримання об'єкту кнопки
        _playButton.clicked += PlayButtonClicked; // підпис на подію
        _upgradesButton = _UIDoc.rootVisualElement.Q<Button>("UpgradesButton");
        _upgradesButton.clicked += UpgradesButtonClicked;
        _settingsButton = _UIDoc.rootVisualElement.Q<Button>("SettingsButton");
        _exitButton = _UIDoc.rootVisualElement.Q<Button>("ExitButton");
        _exitButton.clicked += ExitButtonClicked;
    }*/

    public void PlayButtonClicked() // загрузка сцени симулятора
    {
        SceneManager.LoadScene(1);
    }

    public void UpgradesButtonClicked() //загрузка сцени характеристик
    {
        SceneManager.LoadScene(2);
    }

    public void ExitButtonClicked()
    {
        Application.Quit(); // вихід з програми
    }
}
