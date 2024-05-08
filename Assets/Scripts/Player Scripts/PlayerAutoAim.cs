using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAim : MonoBehaviour
{
    [SerializeField] private PlayerFOV _playerFOV;
    [SerializeField] private GameObject _aimIcon;
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;

    public bool IsActive { get; set; }

    private bool _isReady;

    public bool IsReady => _isReady;

    private void Start()
    {
        _camera = Camera.main;
        IsActive = true;
    }

    private void Update()
    {
        if (!_target)
        {
            try
            {
                _target = FindObjectOfType<MainTarget>().transform;
            }
            catch(NullReferenceException ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }

    private void LateUpdate() // викликається після Update чи FixedUpdate
    {
        if (_playerFOV.IsVisible && _target && IsActive)
        {
            Debug.Log("IsVisible");
            _aimIcon.SetActive(true);
            _aimIcon.transform.position = _camera.WorldToScreenPoint(_target.position);
            StartCoroutine(PreperingToShot(3f));
        }
        else
        {
            _aimIcon.SetActive(false);
            _isReady = false;
            StopAllCoroutines();
        }

        if (_isReady)
            Debug.Log("ready");

    }

    private IEnumerator PreperingToShot(float delay)
    {
        if (!_isReady)
        {
            _aimIcon.transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            yield return new WaitForSeconds(delay);
            _isReady = true;
        }
    }
}
