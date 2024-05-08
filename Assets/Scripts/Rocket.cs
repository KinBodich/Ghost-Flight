using System.Collections;
using UnityEngine;

public class Rocket : MonoBehaviour, IDataPersistence
{
    [SerializeField] private float _speed;
    [SerializeField] private PlayerMovement _player;

    [SerializeField] private MainTarget _mainTarget;

    public PlayerAutoAim PlayerAim { get; set; }
    public bool IsHoming { get; set; }
    public Vector3 TravelRotation { get; set; }
    public static int SpeedIncrement { get; set; } = 10;

    public bool IsLaunched { get; set; }

    private void Start()
    {
        _player = FindObjectOfType<PlayerMovement>();
        PlayerAim = FindObjectOfType<PlayerAutoAim>();
    }

    private void Update()
    {
        if(!_mainTarget)
        {
            _mainTarget = FindObjectOfType<MainTarget>();
        }

        if(_mainTarget && transform.position.z > _mainTarget.transform.position.z + 50f && !transform.parent)
        {
            StartCoroutine(RocketDestroy());
        }
    }

    private void FixedUpdate()
    {
        if (transform.parent)
        {
            return;
        }
        if (_mainTarget.transform && IsHoming)
        {
            HomingMissile();
        }
        else
        {
            StraightMissile();
        }
    }

    private void HomingMissile()
    {
        _speed = _mainTarget.Speed + SpeedIncrement;
        Vector3 directionToTarget = _mainTarget.transform.position - transform.position;
        Vector3 currentDirection = transform.forward;
        float maxTurnSpeed = 25f;
        Vector3 resultingDirection = Vector3.RotateTowards(currentDirection, directionToTarget, maxTurnSpeed * Mathf.Deg2Rad * Time.deltaTime, 1f); // поворот в напрямку цілі
        transform.rotation = Quaternion.LookRotation(resultingDirection);
        transform.Translate(Vector3.forward * _speed * Time.deltaTime); // рух ракети
    }

    private void StraightMissile()
    {
        _speed = _player.Speed + 50;
        IsHoming = false;
        transform.Translate(Vector3.forward * _speed * Time.deltaTime); // рух ракети
        transform.eulerAngles = TravelRotation; // напрямок руху
    }

    private IEnumerator RocketDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    public void LoadData(GameData data)
    {
        SpeedIncrement = data.RocketSpeedIncrement;
    }

    public void SaveData(GameData data)
    {
        data.RocketSpeedIncrement = SpeedIncrement;
    }
}
