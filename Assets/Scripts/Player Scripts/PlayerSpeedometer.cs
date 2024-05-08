using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerSpeedometer : MonoBehaviour
{
    private Transform _targetTransform;
    private PlayerMovement _playerController;
    private TextMeshProUGUI _speedText;
    private int _displayedSpeed;

    private void Start()
    {
        _speedText = GetComponent<TextMeshProUGUI>();
        _playerController = FindObjectOfType<PlayerMovement>();
        if(!_targetTransform)
        {
            try
            {
                _targetTransform = FindObjectOfType<MainTarget>().transform;
            }
            catch(NullReferenceException ex)
            {
                Debug.Log(ex.Message);
            }
        }
    }

    private void Update()
    {
        if(!_targetTransform)
        {
            try
            {
                _targetTransform = FindObjectOfType<MainTarget>().transform;
            }
            catch (NullReferenceException ex)
            {
                Debug.Log(ex.Message);
            }
        }

        DisplaySpeed();
    }

    private void DisplaySpeed()
    {
        _displayedSpeed = Mathf.RoundToInt(_playerController.Speed * 20f);
        _speedText.SetText(_displayedSpeed.ToString());
    }
}
