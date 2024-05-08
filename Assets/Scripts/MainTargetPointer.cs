using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class MainTargetPointer : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _pointerIconTransform;
    [SerializeField] private GameObject _pointerIcon;
    [SerializeField] private TextMeshProUGUI _distanceText;

    public bool IsActive { get; set; }

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        _camera = Camera.main;
        IsActive = true;
    }

    private void LateUpdate()
    {
        if(!IsActive) return;
        Vector3 fromPlayerToTarget = transform.position - _playerTransform.position;
        Ray ray = new Ray(_playerTransform.position, fromPlayerToTarget);
        Debug.DrawRay(_playerTransform.position, fromPlayerToTarget);

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera); // визначення країв екрану

        float minDistance = Mathf.Infinity;
        int planeIndex = 0;

        for (int i = 0; i < 4; i++)
        {
            if(planes[i].Raycast(ray, out float distance))
            {
                if(distance < minDistance)
                {
                    minDistance = distance;
                    planeIndex = i;
                }
            }
        }
        minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToTarget.magnitude);

        Vector3 worldPosition = ray.GetPoint(minDistance);

        _pointerIconTransform.position = _camera.WorldToScreenPoint(worldPosition);
        _distanceText.transform.position = _camera.WorldToScreenPoint(worldPosition);
        _pointerIconTransform.rotation = GetIconRotation(planeIndex);
        GetDistanceTextPosition(planeIndex);

        if (fromPlayerToTarget.magnitude > minDistance) // відображення стрілки
        {
            _pointerIcon.SetActive(true);
            _distanceText.gameObject.SetActive(true);

        }
        else
        {
            _pointerIcon.SetActive(false);
            _distanceText.gameObject.SetActive(false);
        }
    }

    private Quaternion GetIconRotation(int planeIndex) // поворот стрілки
    {
        if (planeIndex == 0)
            return Quaternion.Euler(0, 0, 90);
        else if (planeIndex == 1)
            return Quaternion.Euler(0, 0, -90);
        else if(planeIndex == 2)
            return Quaternion.Euler(0, 0, 180);
        else if (planeIndex == 3)
            return Quaternion.Euler(0, 0, 0);

        return Quaternion.identity;
    }

    private void GetDistanceTextPosition(int planeIndex) // позиція тексту відстані до цілі
    {
        if (planeIndex == 0)
            _distanceText.alignment = TextAlignmentOptions.Right;
        else if (planeIndex == 1)
            _distanceText.alignment = TextAlignmentOptions.Left;
        else if (planeIndex == 2)
            _distanceText.alignment = TextAlignmentOptions.Top;
        else if (planeIndex == 3)
            _distanceText.alignment = TextAlignmentOptions.Bottom;
    }
}
