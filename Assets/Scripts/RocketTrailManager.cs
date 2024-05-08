using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketTrailManager : MonoBehaviour
{
    private Rocket _rocket;
    [SerializeField] private TrailRenderer _trailRenderer;

    private void Start()
    {
        _rocket = GetComponent<Rocket>();
        _trailRenderer.enabled = false;
    }

    private void Update()
    {
        if (_rocket.IsLaunched)
            _trailRenderer.enabled = true;
    }
}
