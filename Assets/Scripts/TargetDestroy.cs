using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDestroy : MonoBehaviour
{
    [SerializeField] private GameObject _targetModel;
    public event Action OnTargetDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rocket>() || collision.gameObject.GetComponent<PlayerMovement>())
        {
            OnTargetDestroy?.Invoke();
            
            var explosionParticle = collision.gameObject.GetComponentInChildren<ExplosionManagement>();
            explosionParticle.transform.parent = null;
            explosionParticle.ReadyToShow = true;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
