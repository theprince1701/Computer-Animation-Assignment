using UnityEngine;

[System.Serializable]
public struct InterpolationProperties
{
   public Interpolation InterpolationType;
   public Easing Easing;
   public AnimationCurve Curve;
   
   [Range(1, 20)]
   public float MaxTime;
   [Range(0.01f, 20)] 
   public float InterpolationPower;
   
   public float interpolationCurrentTime { get; set; }
}
