using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerDistance : MonoBehaviour
{
    [SerializeField] private MainTargetPointer _mainTargetPointer;
    private float _distanceToTarget;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private TextMeshProUGUI _distanceText;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMovement>().transform;
        if (!_mainTargetPointer)
        {
            StartCoroutine(FindTargetDelay());
        }
    }

    private void Update()
    {
        if (!_mainTargetPointer)
        {
            try
            {
                _mainTargetPointer = FindObjectOfType<MainTargetPointer>();
            }
            catch(NullReferenceException ex)
            {
                Debug.Log(ex.Message);
            }
        }
        else
        {
            DisplayDistance();
        }
    }

    private void DisplayDistance()
    {
        _distanceToTarget = Vector3.Distance(transform.position, _playerTransform.position) * 1f;
        _distanceText.SetText(Mathf.RoundToInt(_distanceToTarget).ToString());
    }

    private IEnumerator FindTargetDelay()
    {
        yield return new WaitForSeconds(0.1f);
        _mainTargetPointer = FindObjectOfType<MainTargetPointer>();
    }
}
