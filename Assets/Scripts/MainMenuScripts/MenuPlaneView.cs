using UnityEngine;

public class MenuPlaneView : MonoBehaviour
{
    private Transform _planeTransform;
    private float _rotationSpeed = 20;

    private void Start()
    {
        _planeTransform = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        _planeTransform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
    }
}
