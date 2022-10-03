using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// this class is a procedural jump animation showcasing how the Interpolation System can be used
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputAction jumpAction;
    
    [Header("Jump")] 
    
    [SerializeField] private float jumpPower;
    private Rigidbody _rigidbody;

    private PlayerInterpolation _playerInterpolation;
    private bool _grounded;
    private bool _jumpInProgress;
    private bool _anticipationInProgress;

    private float _anticipationTimer;

    private bool _sentCall;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInterpolation = GetComponent<PlayerInterpolation>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_grounded) 
            return;
        
        if (_rigidbody.velocity.magnitude <= 1.0f)
        {
            
            _grounded = true;
            _rigidbody.velocity = Vector3.zero;
            _playerInterpolation.SetInterpolation("jump_land");
        }
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
        if (jumpAction.IsPressed() && _grounded)
        {
            if (!_sentCall)
            {
                SendAnticipationCall();
            }

            _anticipationTimer += Time.deltaTime;
        }
        else
        {
            if (_sentCall && !_jumpInProgress)
            {
                Jump();
            }
        }
    }

    private void SendAnticipationCall()
    {
        _playerInterpolation.SetInterpolation("jump_anticipation");
        _sentCall = true;
        _jumpInProgress = false;
    }

    private void Jump()
    {
        _playerInterpolation.SetInterpolation("jump_inair");
        _rigidbody.AddForce(Vector3.up * (_anticipationTimer * jumpPower), ForceMode.Impulse);
        _anticipationTimer = 0.0f;
        _sentCall = false;
        _jumpInProgress = true;
        _grounded = false;
    }
}
