using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class LandInterpolation : InterpolationBase
{
    private Transform _playerTransform;
    private Vector3 _defaultScale;
    
    public override void StartInterpolation(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _defaultScale = Vector3.one;
    }

    public override void UpdateInterpolation()
    {
        float t = interpolationCurrentTime / maxTime;

        if (t >= 0.90f)
        {
            _playerTransform.GetComponent<PlayerMovement>().SwitchCurrentInterpolation(null);
        }
        
        interpolationCurrentTime += Time.smoothDeltaTime;
        _playerTransform.localScale = Vector3.Lerp(_playerTransform.localScale, _defaultScale, Time.deltaTime * 5f);
    }

    public override void ExitInterpolation()
    {
        _playerTransform.localScale = _defaultScale;
    }
}
