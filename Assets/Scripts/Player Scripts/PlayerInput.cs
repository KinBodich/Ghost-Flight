using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    private float _verticalInput;
    private bool _isSpeedUp, _isBrakes, _isSliderValueChange;
    [SerializeField] private Slider _sliderInput;

    [SerializeField] private bool _isMobile;

    public bool IsSpeedUp => _isSpeedUp;
    public bool IsBrakes => _isBrakes;
    public bool IsSliderValueChange => _isSliderValueChange;
    public float VerticalInput => _verticalInput;

    public event Action SpeedUp;

    private void Update()
    {
        if (_isMobile) // переключання між режимами для мобільних пристроїв та для пк
            CalculateVerticalInput();
        else
            _verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isSpeedUp = true;
            SpeedUp?.Invoke();
        }
        else
            _isSpeedUp = false;

    }

    private void CalculateVerticalInput()
    {
        if (_isSliderValueChange)
            _verticalInput = _sliderInput.value;
        else
        {
            _sliderInput.value = 0;
            _verticalInput = 0;
        }
    }

    public void SpeedUpButtonDown() 
    {
        _isSpeedUp = true;
        SpeedUp?.Invoke();
    }

    public void SpeedUpButtonUp()
    {
        _isSpeedUp = false;
    }

    public void BrakesButtonDown()
    {
        _isBrakes = true;
    }

    public void BrakesButtonUp()
    {
        _isBrakes = false;
    }

    public void SliderValueDown()
    {
        _isSliderValueChange = true;
    }

    public void SliderValueUp()
    {
        _isSliderValueChange = false;
    }
}
