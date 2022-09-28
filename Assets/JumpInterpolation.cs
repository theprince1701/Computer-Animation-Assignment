using UnityEngine;

[CreateAssetMenu()]
public class JumpInterpolation : InterpolationBase
{
    [SerializeField] private float jumpForce;
    
    private Transform _playerTransform;
    private Vector3 _defaultScale;

    private float _anticipationPower;
    private Rigidbody _rigidbody;
    
    public override void StartInterpolation(Transform playerTransform)
    {
        _playerTransform = playerTransform;
        _defaultScale = _playerTransform.localScale;
        interpolationCurrentTime = 0.0f;

        _anticipationPower = _playerTransform.GetComponent<PlayerMovement>().anticipationProperties
            .interpolationCurrentTime;
        
        _rigidbody = playerTransform.GetComponent<Rigidbody>();
        _rigidbody.AddForce(_playerTransform.up * _anticipationPower * jumpForce , ForceMode.Impulse);
        interpolationCurrentTime = 0.0f;
    }

    public override void UpdateInterpolation()
    {
        float t = interpolationCurrentTime / maxTime;
        
        float interpolationPower =
            Utility.CalculateInterpolation(this, 0.0f, maxTime, t);

        Vector3 interpolationScale =
            new Vector3(0.0f, interpolationPower * this.interpolationPower * _anticipationPower, 0.0f);

        interpolationCurrentTime += Time.smoothDeltaTime;
        _playerTransform.localScale = Vector3.Lerp(_playerTransform.localScale, _defaultScale + interpolationScale, Time.deltaTime * 5f);
    }

    public override void ExitInterpolation()
    {
    }
}
