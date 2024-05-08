using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _offset = new Vector3(22, 4, 8);

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
