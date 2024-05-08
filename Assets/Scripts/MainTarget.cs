using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainTarget : MonoBehaviour
{
    [SerializeField] private float _speed = 101;
    [SerializeField] private float _maxSpeed = 112;
    [SerializeField] private float _rotationSpeed = 1.2f;

    public float Speed => _speed;

    private void FixedUpdate()
    {
        _speed += 0.7f * Time.deltaTime; 
        CalculateMaxSpeed();

        transform.Translate(Vector3.forward * Time.deltaTime * _speed); // рух ракети

        Vector3 movementDirection = new Vector3(0, transform.position.y, transform.position.z);//отримання напрямку руху
        movementDirection.Normalize();

        if(movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime); //поворот ракети
        }
    }

    private void CalculateMaxSpeed()
    {
        if (_speed >= _maxSpeed)
        {
            _speed = _maxSpeed;
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rocket>() || collision.gameObject.GetComponent<PlayerMovement>())
        { 
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }*/
}
