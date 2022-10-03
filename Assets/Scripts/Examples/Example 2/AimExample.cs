using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// this class is an aiming example of different ways to use the Interpolation System.
/// </summary>
public class AimExample : MonoBehaviour
{
    [SerializeField] private InputAction aimAction;

    private PlayerInterpolation _interpolationManager;
    private bool _aiming;

    public bool Aiming => _aiming;

    private void OnEnable() => aimAction.Enable();
    private void OnDisable() => aimAction.Disable();
    

    private void Awake()
    {
        _interpolationManager = GetComponent<PlayerInterpolation>();
    }

    private void Start()
    {       
        aimAction.performed += ctx => AimWeapon();
    }

    private void AimWeapon()
    {
        _aiming = !_aiming;

        if (_aiming)
        {
            _interpolationManager.SetInterpolation("aim");
        }
        else
        {
            _interpolationManager.ExitInterpolation();
        }
    }
}
