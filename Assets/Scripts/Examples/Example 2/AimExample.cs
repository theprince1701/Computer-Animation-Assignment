using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimExample : MonoBehaviour
{
    [SerializeField] private InputAction aimAction;

    private PlayerInterpolation _interpolationManager;
    private bool _aiming;

    private void OnEnable() => aimAction.Enable();

    private void OnDisable() => aimAction.Disable();


    private void Awake()
    {
        _interpolationManager = GetComponent<PlayerInterpolation>();

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
