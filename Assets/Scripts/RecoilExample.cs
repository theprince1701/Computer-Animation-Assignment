using UnityEngine;
 using UnityEngine.InputSystem;
 using Random = UnityEngine.Random;


/// <summary>
/// This is an example class showcasing how recoil can be achieved with the interpolation system.
/// </summary>
 public class RecoilExample : MonoBehaviour
 { 
     [SerializeField] private InputAction fireAction;
     [SerializeField] private Transform recoilPositionTransform;
     [SerializeField] private Transform recoilRotationTransform;

     [SerializeField] private float dampTime;
     [SerializeField] private float recoil1 = 35;
     [SerializeField] private float recoil2 = 50;
     [SerializeField] private float recoil3 = 35;
     [SerializeField] private float recoil4 = 50;

     [SerializeField] private Vector3 recoilPosition;
     [SerializeField] private Vector3 recoilRotation;

     [Space] 
      
     [SerializeField] private Interpolation interpolation;
     [SerializeField] private Easing easing;
      
     private Vector3 _recoilAimPosition => recoilPosition / 2f;
     private Vector3 _recoilAimRotation => recoilRotation / 2f;
 
     private CustomPositionInterpolation _positionInterpolation;
     private CustomRotationInterpolation _rotationInterpolation;

     private Vector3 _recoil1Pos;
     private Vector3 _recoil2Pos;
     private Vector3 _recoil3Pos;
     private Vector3 _recoil4Pos;

     private AimExample _aimExample;

     private void Awake()
     {
         fireAction.performed += ctx => UpdateRecoil();
         _aimExample = GetComponent<AimExample>();
     }

     private void OnEnable() => fireAction.Enable();
     private void OnDisable() => fireAction.Disable();

     public void UpdateRecoil() 
     {
          _positionInterpolation = InterpolationTransitions.GetInterpolationPosition(interpolation, easing);
          _rotationInterpolation = InterpolationTransitions.GetInterpolationRotation(interpolation, easing);
          
          _recoil1Pos += new Vector3(recoilRotation.x, Random.Range(-recoilRotation.y, recoilRotation.y), 
              Random.Range(-recoilRotation.z, recoilRotation.z));

          if (_aimExample.Aiming)
              _recoil1Pos /= 2;
          
          _recoil3Pos += new Vector3(Random.Range(-recoilPosition.x, recoilPosition.x), 
              Random.Range(-recoilPosition.y, recoilPosition.y), recoilPosition.z);

          if (_aimExample.Aiming)
              _recoil3Pos /= 2;
     }

      private void Update()
      {
          if (_positionInterpolation == null || _rotationInterpolation == null)
              return;
          
          if(fireAction.IsPressed())
              UpdateRecoil();
          
          _recoil1Pos = Vector3.Lerp(_recoil1Pos, Vector3.zero, recoil1 * Time.deltaTime);
          _recoil2Pos = Vector3.Lerp(_recoil2Pos, _recoil1Pos, recoil2 * Time.deltaTime);
          _recoil3Pos = Vector3.Lerp(_recoil3Pos, Vector3.zero, recoil3 * Time.deltaTime);
          _recoil4Pos = Vector3.Lerp(_recoil4Pos, _recoil3Pos, recoil4 * Time.deltaTime);

          recoilPositionTransform.localPosition =
              _positionInterpolation(recoilPositionTransform.localPosition, _recoil3Pos, dampTime);

          recoilRotationTransform.localRotation = _rotationInterpolation(recoilRotationTransform.localRotation,
              Quaternion.Euler(_recoil1Pos), dampTime);
      }
}
