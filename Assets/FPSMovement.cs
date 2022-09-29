using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovement : MonoBehaviour
{
    [SerializeField] private InputAction jumpAction;
    [SerializeField] private float jumpHeight;

    private PlayerInterpolation _weaponInterpolation;
    private Rigidbody _rigidbody;

    private void OnEnable() => jumpAction.Enable();
    private void OnDisable() => jumpAction.Disable();
    
    private void Awake()
    {
        _weaponInterpolation = GetComponentInChildren<PlayerInterpolation>();
        _rigidbody = GetComponent<Rigidbody>();

        jumpAction.performed += ctx => Jump();
    }

    private void Jump()
    {
        _weaponInterpolation.SetInterpolation("jump");
        _rigidbody.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        _weaponInterpolation.ExitInterpolation();
    }
}
