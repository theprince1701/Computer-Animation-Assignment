using UnityEngine;

[CreateAssetMenu()]
public class AnticipationInterpolation : InterpolationBase
{
    [SerializeField] private float spinSpeed = 1f;
    
    private Transform _playerTransform;
    private Vector3 _defaultScale;

    private float _spinInterval;
    
    public override void StartInterpolation(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _defaultScale = _playerTransform.localScale;
        interpolationCurrentTime = 0.0f;
        _spinInterval = 0.0f;
    }

    public override void UpdateInterpolation()
    {
        float t = interpolationCurrentTime / maxTime;

        float interpolation =
            -Utility.CalculateInterpolation(this, 0.0f, maxTime, t);

        if (t > 0.5f)
        {
            Vector3 interpolationSpin = _playerTransform.eulerAngles;
            _spinInterval += Time.smoothDeltaTime * spinSpeed;

            interpolationSpin.y = interpolation * _spinInterval;

            _playerTransform.eulerAngles = interpolationSpin;
        }
        else
        {
            Vector3 interpolationScale =
                new Vector3(0.0f, interpolation * interpolationPower, 0.0f);

            interpolationCurrentTime += Time.smoothDeltaTime;
            _playerTransform.localScale = _defaultScale + interpolationScale;
        }
    }

    public override void ExitInterpolation()
    {
        
    }
}
