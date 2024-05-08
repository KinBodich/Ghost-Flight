using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerSpeed : MonoBehaviour
{
    private float _playerSpeed;
    private Rigidbody _playerRb;
    [SerializeField] private TextMeshProUGUI _speedText;

    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        DisplaySpeed();
    }

    private void DisplaySpeed()
    {
        _playerSpeed = _playerRb.velocity.magnitude;
        _speedText.SetText(_playerSpeed.ToString());
    }
}
