using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{
    private PlayerInput _playerInput;

    [SerializeField] private float _speed = 100;
    [SerializeField] private float _minSpeed = 75;

    private float MaxSpeed { get; set; } = 122.5f;
    public static float Acceleration { get; set; } = 2;
    public static float Deceleration { get; set; } = 5;
    public static float AirResistance { get; set; } = 1;
    public static float IdleSpeed { get; set; } = 100;
    public static float RotationSpeed { get; set; } = 50;

    public float Speed => _speed;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _speed = IdleSpeed;

    }

    private void FixedUpdate()
    {
        MovementMechanics();

        CalculateMaxSpeed(); // обчислення максимальної швидкості
        CalculateMinSpeed(); // обчислення мінімальної швидкості

        transform.Translate(Vector3.forward * Time.deltaTime * _speed); // рух уперед
        RotationMechanics();
        
    }

    private void RotationMechanics()
    {
        float minRotation = -60f;
        float maxRotation = 60f;

        transform.localEulerAngles = new Vector3(Mathf.Clamp((transform.localEulerAngles.x <= 180) ?
            transform.localEulerAngles.x : -(360 - transform.localEulerAngles.x), minRotation, maxRotation),
            transform.localEulerAngles.y, transform.localEulerAngles.z);

        transform.Rotate(Vector3.left * RotationSpeed * Time.deltaTime * _playerInput.VerticalInput);
    }

    private void MovementMechanics() // механіки руху
    {
        if (_playerInput.IsSpeedUp || Input.GetKey(KeyCode.LeftShift))
        {
            _speed += Acceleration * Time.deltaTime; ;
        }
        else if (_playerInput.IsBrakes || Input.GetKey(KeyCode.Space))
        {
            _speed -= Deceleration * Time.deltaTime;
        }
        else if (_speed > IdleSpeed + 0.5f)
        {
            _speed -= AirResistance * Time.deltaTime;
        }
        else if (_speed < IdleSpeed - 0.5f)
        {
            _speed += AirResistance * Time.deltaTime;
        }
        else if (_speed < IdleSpeed + 0.5f || _speed > IdleSpeed - 0.5f)
            _speed = IdleSpeed;
    }

    private void CalculateMaxSpeed()
    {
        if (_speed >= MaxSpeed)
            _speed = MaxSpeed;
    }

    private void CalculateMinSpeed()
    {
        if (_speed <= _minSpeed)
            _speed = _minSpeed;
    }

    public void LoadData(GameData data)
    {
        MaxSpeed = data.PlayerMaxSpeed;
        Acceleration = data.PlayerAcceleration;
        Deceleration = data.PlayerDeceleration;
        RotationSpeed = data.PlayerRotationSpeed;
    }

    public void SaveData(GameData data)
    {
        data.PlayerMaxSpeed = MaxSpeed;
        data.PlayerAcceleration = Acceleration;
        data.PlayerDeceleration = Deceleration;
        data.PlayerRotationSpeed = RotationSpeed;
    }
}