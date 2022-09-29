using UnityEngine;

public static class InterpolationTransitions
{
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
    
    public static Vector3 EaseSinePosition(Vector3 start, Vector3 end, float time)
    {
        float t = -(Mathf.Cos(Mathf.PI * time) - 1.0f) / 2.0f;
        
        return Vector3.Lerp(start, end, t);
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
}
