using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UpgradesMainMenuManager : MonoBehaviour
{
    private UIDocument _UIDoc;  // �������� � ��������
    [SerializeField] private UIDocument _planeCharacteristicsUIDoc, _rocketsCharacteristicsUIDoc;  // ��������� � �������� ������������� ����� �� ��������
    private Button _planeCharacteristicsButton, _rocketsCharacteristicsButton, _backButton; // �������� ������

    

    private VisualElement _thisUpgradesPanel; // ��� ����������� � ����

    private void Awake()
    {
        _planeCharacteristicsUIDoc.gameObject.SetActive(true); 
        _rocketsCharacteristicsUIDoc.gameObject.SetActive(true);
        _UIDoc = GetComponent<UIDocument>(); // ��������� ��'���� ���������
        _thisUpgradesPanel = _UIDoc.rootVisualElement.Q<VisualElement>("Upgrades"); // ��������� ��'���� ��� �����������

        _planeCharacteristicsButton = _UIDoc.rootVisualElement.Q<Button>("PlaneCharacteristicsButton"); // ��������� ��'���� ������
        var planeCharacteristicsPanel = _planeCharacteristicsUIDoc.rootVisualElement.Q<VisualElement>("Upgrades"); // ��������� ��'���� ��� �����������
        planeCharacteristicsPanel.visible = false;
        _planeCharacteristicsButton.clicked += () => OnUpgradesButtonClicked(planeCharacteristicsPanel); // ����� �� ����

        _rocketsCharacteristicsButton = _UIDoc.rootVisualElement.Q<Button>("RocketsCharacteristicsButton");
        var rocketsCharacteristicsPanel = _rocketsCharacteristicsUIDoc.rootVisualElement.Q<VisualElement>("Upgrades");
        _rocketsCharacteristicsButton.clicked += () => OnUpgradesButtonClicked(rocketsCharacteristicsPanel);

        _backButton = _UIDoc.rootVisualElement.Q<Button>("BackButton");
        _backButton.clicked += OnBackButtonClicked;
    }

    private void OnUpgradesButtonClicked(VisualElement otherPanel) // ����� ��� ����������� �������
    {
        _thisUpgradesPanel.visible = false;
        otherPanel.visible = true;
    }

    private void OnBackButtonClicked() // ����� � ���� �������������
    {
        SceneManager.LoadScene(0);
    }
}
