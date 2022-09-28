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

     public InterpolationBase anticipationProperties;
     public InterpolationBase jumpProperties;
     public InterpolationBase landProperties;
    
    
    private Rigidbody _rigidbody;

    private Vector3 _defaultScale;
    private bool _grounded;
    private bool _jumpInProgress;
    private bool _anticipationInProgress;

    private InterpolationBase _currentInterpolation;
 
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _defaultScale = transform.localScale;
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
            SwitchCurrentInterpolation(anticipationProperties);
            _anticipationInProgress = true;
        }
        else
        {
            if (_anticipationInProgress)
            {
                SwitchCurrentInterpolation(jumpProperties);
                _anticipationInProgress = false;
                _jumpInProgress = true;
            }
        }
        
        
        if(_currentInterpolation != null)
            _currentInterpolation.UpdateInterpolation();
        
        RaycastHit hit;
        _grounded = Physics.Raycast(transform.position, -transform.up, out hit, 0.5f);
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (!_jumpInProgress)
            return;
        
        Debug.Log("land");
        SwitchCurrentInterpolation(landProperties);
        _jumpInProgress = false;
    }

    public void SwitchCurrentInterpolation(InterpolationBase nextInterpolation)
    {
        if (_currentInterpolation == nextInterpolation)
            return;
        
        if(_currentInterpolation != null)
            _currentInterpolation.ExitInterpolation();

        _currentInterpolation = nextInterpolation;
        
        if(_currentInterpolation)
            _currentInterpolation.StartInterpolation(transform);
    }
}
