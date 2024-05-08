using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerRocketLaunch : MonoBehaviour, IDataPersistence
{
    [SerializeField] private List<GameObject> _rocketPrefabs;
    [SerializeField] private GameObject _playerMissilePrefab;
    [SerializeField] private PlayerFOV _playerFOV;
    [SerializeField] private Transform _target;
    [SerializeField] private List<Vector3> _rocketPositions;
    [SerializeField] private Transform _missilesParentTransform;
    [SerializeField] private TextMeshProUGUI _rocketCountText;

    private int _activeRocket = 0;
    private bool _isReloading;
    private Vector3 _lastMissilePos;

    public static int MissileCount { get; set; } = 1;
    public static float LaunchDelay { get; set; }
    public static float ReloadTime { get; set; } = 10;

    private void Start()
    {
        for (int i = 0; i < MissileCount; i++)
        {
            _rocketPrefabs.Add(Instantiate(_playerMissilePrefab, _rocketPositions[i], _missilesParentTransform.rotation, _missilesParentTransform));
            _rocketPrefabs[i].transform.localPosition = _rocketPositions[i];
        }
    }

    private void Update()
    {
        if (!_target)
        {
            _target = FindObjectOfType<MainTarget>().transform;
        }

        if (_isReloading)
        {
            StartCoroutine(MissileReload(_lastMissilePos, ReloadTime));
            _isReloading = false;
        }

        DisplayRocketCount();
    }

    private IEnumerator LaunchRocket(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (_activeRocket < _rocketPrefabs.Count && _rocketPrefabs[_activeRocket])
        {
            _lastMissilePos = _rocketPrefabs[_activeRocket].transform.localPosition;
            var currentRocket = _rocketPrefabs[_activeRocket].GetComponent<Rocket>();
            currentRocket.TravelRotation = transform.rotation.eulerAngles;
            _rocketPrefabs[_activeRocket].transform.parent = null;
            currentRocket.IsLaunched = true;
            if (_rocketPrefabs[_activeRocket].GetComponent<Rocket>().PlayerAim.IsReady)
                _rocketPrefabs[_activeRocket].GetComponent<Rocket>().IsHoming = true;
            _rocketPrefabs.RemoveAt(_activeRocket);
            _isReloading = true;
        }
        else
        {
            Debug.Log("NoRockets");
        }
    }

    private IEnumerator MissileReload(Vector3 lastMissilePos, float reloadTime)
    {
        yield return new WaitForSeconds(reloadTime);
        _rocketPrefabs.Add(Instantiate(_playerMissilePrefab, _missilesParentTransform));
        _rocketPrefabs[^1].transform.localPosition = lastMissilePos;
        _rocketPrefabs[^1].transform.rotation = _missilesParentTransform.rotation;
    }

    public void Fire()
    {
        StartCoroutine(LaunchRocket(LaunchDelay));
    }

    private void DisplayRocketCount()
    {
        _rocketCountText.text = Convert.ToString(_rocketPrefabs.Count);
    }

    public void LoadData(GameData data)
    {
        MissileCount = data.PlayerMissileCount;
        LaunchDelay = data.PlayerMissileLaunchDelay;
        ReloadTime = data.RocketReloadTime;
    }

    public void SaveData(GameData data)
    {
        data.PlayerMissileCount = MissileCount;
        data.PlayerMissileLaunchDelay = LaunchDelay;
        data.RocketReloadTime = ReloadTime;
    }
}
