using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterpolation 
{
    Interpolation Interpolation { get; }
    Easing Easing { get; }
    
    AnimationCurve Curve { get; }
    
    float MaxTime { get; }
    float CurrentTime { get; }
    
    void StartInterpolation();
    void UpdateInterpolation();
    void ExitInterpolation();
}
