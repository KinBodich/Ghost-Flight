using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrails : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private TrailRenderer[] _engineTrails;
    [SerializeField] private TrailRenderer[] _wingsTrails;
    private float _trailTime;
    //private bool startCor;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        foreach (var trail in _wingsTrails)
        {
            trail.enabled = false;
        }
        //_playerInput.SpeedUp += EngineTrailsManagement;
    }

    private void FixedUpdate()
    {
        
        EngineTrailsManagement();

        //WingsTrailsManagement();
    }

    private void EngineTrailsManagement()
    {
        foreach (var trail in _engineTrails)
        {
            trail.time = _trailTime;
        }

        if (_playerInput.IsSpeedUp)
            _trailTime = 0.12f;
        else
            _trailTime = 0.1f;
    }

    private void WingsTrailsManagement()
    {
        var startCor = true;
        if (startCor)
        {
            StopCoroutine(nameof(WingsTrailDisable));
            StartCoroutine(WingsTrailDisplay());
            startCor = false;
        }
        else
        {
            StopCoroutine(nameof(WingsTrailDisplay));
            StartCoroutine(WingsTrailDisable());
        }
    }

    private IEnumerator WingsTrailDisplay()
    {
        if (!_wingsTrails[0].enabled && !_wingsTrails[1].enabled)
        {
            yield return new WaitForSeconds(1.5f);
            Debug.Log("on");
            _wingsTrails[0].enabled = true;
            _wingsTrails[1].enabled = true;
        }
        
    }

    private IEnumerator WingsTrailDisable()
    {
        if (_wingsTrails[0].enabled && _wingsTrails[1].enabled)
        {
            yield return new WaitForSeconds(4);
            Debug.Log("off");
            foreach (var trail in _wingsTrails)
            {
                trail.enabled = false;
            }

        }
    }
}
