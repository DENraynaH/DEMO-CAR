using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    [Header("SETTINGS")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _groundDrag;
    [SerializeField] private float _turnAngle;
    [SerializeField] private float _traction;

    private Vector3 _defaultMoveForce;

    private void Update()
    {
        Move();
    }
    
    private void Move()
    {
        _defaultMoveForce += transform.forward * (_moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
        transform.position += _defaultMoveForce * Time.deltaTime;

        float steeringInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector2.up * (steeringInput * _defaultMoveForce.magnitude * _turnAngle * Time.deltaTime));

        _defaultMoveForce *= _groundDrag;
        _defaultMoveForce = Vector3.ClampMagnitude(_defaultMoveForce, _maxSpeed);

        _defaultMoveForce = Vector3.Lerp(_defaultMoveForce.normalized, transform.forward, _traction * Time.deltaTime) * _defaultMoveForce.magnitude;
                  
    }
}
