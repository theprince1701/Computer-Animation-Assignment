using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InterpolationBase : ScriptableObject
{
    public Interpolation interpolationType;
    public Easing easingType;
    public AnimationCurve animationCurve;

    [Range(1, 20)]
    public float maxTime;
    [Range(0.01f, 20)] 
    public float interpolationPower;
   
    public float interpolationCurrentTime { get; set; }

    public abstract void StartInterpolation(Transform playerTransform);
    public abstract void UpdateInterpolation();
    public abstract void ExitInterpolation();
}
