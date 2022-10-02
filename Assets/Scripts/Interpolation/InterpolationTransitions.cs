using UnityEngine;


public enum Interpolation
{
    LINEAR,
    SMOOTH,
    EASE,
    CURVE
}

public enum Easing
{
    SWING_ACROSS,
    SWING_UP,
    BOUNCE_IN,
    BOUNCE_OUT,
    SPRING,
    SINE,
    QUADRATIC,
    CUBIC,
    QUARTIC,
    QUINTIC,
    EXPONENTIAL,
    CIRCLE,
    BACK,
    ELASTIC
}

public static class InterpolationTransitions
{
    public static Vector3 PositionSwingUp(Vector3 source, Vector3 target, float lerp)
    {
        return new Vector3(
            Mathf.Lerp(source.x, target.x, EaseOutQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.y, target.y, EaseInQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.z, target.z, lerp)
        );
    }

    public static Vector3 PositionSwingAcross(Vector3 source, Vector3 target, float lerp)
    {
        return new Vector3(
            Mathf.Lerp(source.x, target.x, EaseInQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.y, target.y, EaseOutQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.z, target.z, lerp)
        );
    }
    
    public static Quaternion RotationSwingUp(Quaternion source, Quaternion target, float lerp)
    {
        Vector3 rotation = new Vector3(
            Mathf.Lerp(source.x, target.x, EaseOutQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.y, target.y, EaseInQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.z, target.z, lerp));
        
        return Quaternion.Lerp(source, Quaternion.Euler(rotation), lerp);
    }

    public static Quaternion RotationSwingAcross(Quaternion source, Quaternion target, float lerp)
    {
        Vector3 rotation =  new Vector3(
            Mathf.Lerp(source.x, target.x, EaseInQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.y, target.y, EaseOutQuadraticUnclamped(lerp)),
            Mathf.Lerp(source.z, target.z, lerp)
        );
        
        return Quaternion.Lerp(source, Quaternion.Euler(rotation), lerp);
    }

    
    public static Vector3 EaseSinePosition(Vector3 start, Vector3 end, float time)
    {
        float t = -(Mathf.Cos(Mathf.PI * time) - 1.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Vector3 EaseSpringPosition(Vector3 start, Vector3 end, float value)
    {
        value = Mathf.Clamp01(value);
        value = (Mathf.Sin(value * Mathf.PI * (0.2f + 2.5f * value * value * value)) * Mathf.Pow(1f - value, 2.2f) + value) * (1f + (1.2f * (1f - value)));
        float t = start.magnitude + (end.magnitude - start.magnitude) * value;

        return Vector3.Lerp(start, end, t);
    }
    
    public static Vector3 LinearPosition(Vector3 start, Vector3 end, float time)
    {
        return Vector3.Lerp(start, end, time);
    }
    
    public static Quaternion LinearRotation(Quaternion start, Quaternion end, float time)
    {
        return Quaternion.Lerp(start, end, time);
    }
    
    public static Vector3 SmoothPosition(Vector3 start, Vector3 end, float time)
    {
        float t = Mathf.SmoothStep(start.magnitude, end.magnitude, time);
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion SmoothRotation(Quaternion start, Quaternion end, float time)
    {
        float t = Mathf.SmoothStep(start.eulerAngles.magnitude, end.eulerAngles.magnitude, time);
        
        return Quaternion.Lerp(start, end, t);
    }
    
    public static Quaternion EaseSineRotation(Quaternion start, Quaternion end, float time)
    {
        float t = -(Mathf.Cos(Mathf.PI * time) - 1.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t);
    }

    public static Vector3 EaseQuadraticPosition(Vector3 start, Vector3 end, float time)
    {
        float t = time < 0.5f ? 2.0f * time * time : 1 - Mathf.Pow(-2.0f * time + 2.0f, 2.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion EaseQuadraticRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time < 0.5f ? 2.0f * time * time : 1 - Mathf.Pow(-2.0f * time + 2.0f, 2.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t);
    }

    public static Vector3 EaseCubicPosition(Vector3 start, Vector3 end, float time)
    {
        float t = time < 0.5f ? 4.0f * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 3.0f) / 2.0f;

        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion EaseCubicRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time < 0.5f ? 4.0f * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 3.0f) / 2.0f;

        return Quaternion.Lerp(start, end, t);
    }

    public static Vector3 EaseQuarticPosition(Vector3 start, Vector3 end, float time)
    {
        float t = time < 0.5f ? 8.0f * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 4.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t); 
    }
    
    public static Quaternion EaseQuarticRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time < 0.5f ? 8.0f * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 4.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t); 
    }

    public static Vector3 EaseQuinticPosition(Vector3 start, Vector3 end, float time)
    {
        float t = time < 0.5f ? 16.0f * time * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 5.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t); 
    }
    
    
    public static Quaternion EaseQuinticRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time < 0.5f ? 16.0f * time * time * time * time * time : 1.0f - Mathf.Pow(-2.0f * time + 2.0f, 5.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t); 
    }

    public static Vector3 EaseExponentialPosition(Vector3 start, Vector3 end, float time)
    {
        float t = time == 0.0f
            ? 0.0f
            : time == 1.0f
                ? 1.0f
                : time < 0.5f ? Mathf.Pow(2.0f, 20.0f * time - 10.0f) / 2.0f
                    : (2.0f - Mathf.Pow(2.0f, -20.0f * time + 10.0f)) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion EaseExponentialRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time == 0.0f
            ? 0.0f
            : time == 1.0f
                ? 1.0f
                : time < 0.5f ? Mathf.Pow(2.0f, 20.0f * time - 10.0f) / 2.0f
                    : (2.0f - Mathf.Pow(2.0f, -20.0f * time + 10.0f)) / 2.0f;
        
        return Quaternion.Lerp(start, end, t);
    }

    public static Vector3 EaseCirclePosition(Vector3 start, Vector3 end, float time)
    {
        float t = time < 0.5f
            ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * time, 2.0f))) / 2.0f
            : (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * time + 2.0f, 2.0f)) + 1.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
    }

    public static Quaternion EaseCircleRotation(Quaternion start, Quaternion end, float time)
    {
        float t = time < 0.5f
            ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * time, 2.0f))) / 2.0f
            : (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * time + 2.0f, 2.0f)) + 1.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t);
    }
    
    public static Vector3 EaseBackPosition(Vector3 start, Vector3 end, float time)
    {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;
        
        float t = time < 0.5
            ? (Mathf.Pow(2.0f * time, 2.0f) * ((c2 + 1.0f) * 2.0f * time - c2)) / 2.0f
            : (Mathf.Pow(2.0f * time - 2.0f, 2.0f) * ((c2 + 1.0f) * (time * 2.0f - 2.0f) + c2) + 2.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion EaseBackRotation(Quaternion start, Quaternion end, float time)
    {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;
        
        float t = time < 0.5
            ? (Mathf.Pow(2.0f * time, 2.0f) * ((c2 + 1.0f) * 2.0f * time - c2)) / 2.0f
            : (Mathf.Pow(2.0f * time - 2.0f, 2.0f) * ((c2 + 1.0f) * (time * 2.0f - 2.0f) + c2) + 2.0f) / 2.0f;
        
        return Quaternion.Lerp(start, end, t);
    }

    public static Vector3 EaseElasticPosition(Vector3 start, Vector3 end, float time)
    {
        const float c5 = (2.0f * Mathf.PI) / 4.5f;

        float t = time == 0.0f
            ? 0.0f
            : time == 1.0f
                ? 1.0f
                : time < 0.5f
                    ? -(Mathf.Pow(2.0f, 20.0f * time - 10.0f) * Mathf.Sin((20.0f * time - 11.125f) * c5)) / 2.0f
                    : (Mathf.Pow(2.0f, -20.0f * time + 10.0f) * Mathf.Sin((20.0f * time - 11.125f) * c5)) / 2.0f + 1.0f;
        
        return Vector3.Lerp(start, end, t);
    }
    
    public static Quaternion EaseElasticRotation(Quaternion start, Quaternion end, float time)
    {
        const float c5 = (2.0f * Mathf.PI) / 4.5f;

        float t = time == 0.0f
            ? 0.0f
            : time == 1.0f
                ? 1.0f
                : time < 0.5f
                    ? -(Mathf.Pow(2.0f, 20.0f * time - 10.0f) * Mathf.Sin((20.0f * time - 11.125f) * c5)) / 2.0f
                    : (Mathf.Pow(2.0f, -20.0f * time + 10.0f) * Mathf.Sin((20.0f * time - 11.125f) * c5)) / 2.0f + 1.0f;
        
        return Quaternion.Lerp(start, end, t);
    }
    
    public static Vector3 EaseInBounce(Vector3 start, Vector3 end, float time)
    {
        float d = 1f;
        return end - EaseOutBounce(Vector3.zero, end, d - time) + start;
    }

    public static Vector3 EaseOutBounce(Vector3 start, Vector3 end, float value)
    {
        value /= 1f;
        float t = 0.0f;
        if (value < (1 / 2.75f))
        {
            t = end.magnitude * (7.5625f * value * value) + start.magnitude;
        }
        else if (value < (2 / 2.75f))
        {
            value -= (1.5f / 2.75f);
            t = end.magnitude * (7.5625f * (value) * value + .75f) + start.magnitude;
        }
        else if (value < (2.5 / 2.75))
        {
            value -= (2.25f / 2.75f);
            t = end.magnitude * (7.5625f * (value) * value + .9375f) + start.magnitude;
        }
        else
        {
            value -= (2.625f / 2.75f);
            t = end.magnitude * (7.5625f * (value) * value + .984375f) + start.magnitude;
        }

        return Vector3.Lerp(start, end, t);
    }
    
    
    public static float EaseInQuadraticUnclamped(float x)
    {
        return x * x;
    }
    
    public static float EaseOutQuadraticUnclamped(float x)
    {
        float y = 1f - x;
        return 1f - (y * y);
    }

    
    public static CustomPositionInterpolation GetInterpolationPosition(Interpolation interpolation, Easing easing)
    {
        if (interpolation == Interpolation.EASE)
        {
            switch (easing)
            {
                
                case Easing.SWING_UP:
                    return PositionSwingUp;
                
                case Easing.SWING_ACROSS:
                    return PositionSwingAcross;
                
                case Easing.BOUNCE_IN:
                    return EaseInBounce;
                
                case Easing.BOUNCE_OUT:
                    return EaseOutBounce;
                
                case Easing.SPRING:
                    return EaseSpringPosition;
                
                case Easing.BACK:
                    return EaseBackPosition;
                
                case Easing.SINE:
                    return EaseSinePosition;
                
                case Easing.CUBIC:
                    return EaseCubicPosition;
                
                case Easing.CIRCLE:
                    return EaseCirclePosition;
                
                case Easing.ELASTIC:
                    return EaseElasticPosition;
                
                case Easing.QUARTIC:
                    return EaseQuarticPosition;
                
                case Easing.QUINTIC:
                    return EaseQuinticPosition;
                
                case Easing.QUADRATIC:
                    return EaseQuadraticPosition;

                case Easing.EXPONENTIAL:
                    return EaseExponentialPosition;
            }
        }
        else
        {
            switch (interpolation)
            {
                case Interpolation.SMOOTH:
                    return SmoothPosition;
                
                case Interpolation.LINEAR:
                    return LinearPosition;
            }
        }

        return null;
    }
    
    
    public static CustomRotationInterpolation GetInterpolationRotation(Interpolation interpolation, Easing easing)
    {
        if (interpolation == Interpolation.EASE)
        {
            switch (easing)
            {
                
                case Easing.SWING_UP:
                    return RotationSwingUp;
                
                case Easing.SWING_ACROSS:
                    return RotationSwingAcross;
                
                case Easing.BACK:
                    return EaseBackRotation;
                
                case Easing.SINE:
                    return EaseSineRotation;
                
                case Easing.CUBIC:
                    return EaseCubicRotation;
                
                case Easing.CIRCLE:
                    return EaseCircleRotation;
                
                case Easing.ELASTIC:
                    return EaseElasticRotation;
                
                case Easing.QUARTIC:
                    return EaseQuarticRotation;
                
                case Easing.QUINTIC:
                    return EaseQuinticRotation;
                
                case Easing.QUADRATIC:
                    return EaseQuadraticRotation;

                case Easing.EXPONENTIAL:
                    return EaseExponentialRotation;
            }
        }
        else
        {
            switch (interpolation)
            {
                case Interpolation.SMOOTH:
                    return SmoothRotation;
                
                case Interpolation.LINEAR:
                    return LinearRotation;
            }
        }

        return null;
    }
}
