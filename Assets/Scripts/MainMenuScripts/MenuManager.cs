using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    private UIDocument _UIDoc; // �������� � ��������
    private Button _playButton, _upgradesButton, _settingsButton, _exitButton; // �������� ������

    /*private void Awake()
    {
        _UIDoc = GetComponent<UIDocument>(); // ��������� ��'���� ���������
        _playButton = _UIDoc.rootVisualElement.Q<Button>("PlayButton"); // ��������� ��'���� ������
        _playButton.clicked += PlayButtonClicked; // ����� �� ����
        _upgradesButton = _UIDoc.rootVisualElement.Q<Button>("UpgradesButton");
        _upgradesButton.clicked += UpgradesButtonClicked;
        _settingsButton = _UIDoc.rootVisualElement.Q<Button>("SettingsButton");
        _exitButton = _UIDoc.rootVisualElement.Q<Button>("ExitButton");
        _exitButton.clicked += ExitButtonClicked;
    }*/

    public void PlayButtonClicked() // �������� ����� ����������
    {
        SceneManager.LoadScene(1);
    }

    public void UpgradesButtonClicked() //�������� ����� �������������
    {
        SceneManager.LoadScene(2);
    }

    public void ExitButtonClicked()
    {
        Application.Quit(); // ����� � ��������
    }
}
