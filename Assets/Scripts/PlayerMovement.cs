using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputAction jumpAction;
    
    [Header("Jump")] 
    
    [SerializeField] private float jumpPower;
    private Rigidbody _rigidbody;
    private Vector3 _defaultScale;

    private PlayerInterpolation _playerInterpolation;
    private bool _grounded;
    private bool _jumpInProgress;
    private bool _anticipationInProgress;

    private float _anticipationTimer;

    private bool _sentCall;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defaultScale = transform.localScale;
        _playerInterpolation = GetComponent<PlayerInterpolation>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_grounded) 
            return;

        _grounded = true;
        _playerInterpolation.SetInterpolation("jump_land");
    }

    private void OnEnable()
    {
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.Disable();
    }

    private void Update()
    {
        if (jumpAction.IsPressed())
        {
            if (!_sentCall)
            {
                _playerInterpolation.SetInterpolation("jump_anticipation");
                _sentCall = true;
                _jumpInProgress = false;
            }

            _anticipationTimer += Time.deltaTime;
        }
        else
        {
            if (_sentCall && !_jumpInProgress)
            {
                _playerInterpolation.SetInterpolation("jump_inair");
                _rigidbody.AddForce(Vector3.up * (_anticipationTimer * jumpPower), ForceMode.Impulse);
                _anticipationTimer = 0.0f;
                _sentCall = false;
                _jumpInProgress = true;
                _grounded = false;
            }
        }
    }
}
