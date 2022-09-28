using System.Collections;
using System.Collections.Generic;
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
public static class Utility
{
    public static bool InRange(Transform viewer, Transform target, float length, float fov)
    {
        // If the target is outside the viewer's sensor region, don't bother continuing
        if ((target.position - viewer.position).magnitude > length)
            return false;

        // We want to determine whether the angle between the player and enemy is less than half the enemy's fov
        // "return angle <= fov * 0.5f;"

        // We can solve for this angle using the dot product
        // a . b = ||a|| * ||b|| * cos(x)

        // We can simplify this equation because we know that a and b are normalized, so we can remove their magnitude
        // a . b = ||a|| * ||b|| * cos(x)
        // a . b = 1 * 1 * cos(x)
        // a . b = cos(x)
        // x = arccos(a . b)

        Vector3 targetDirection = (target.position - viewer.position).normalized;
        Vector3 viewerDirection = viewer.rotation * Vector3.forward;

        //float angle = Mathf.Acos(Vector3.Dot(targetDirection, viewerDirection)) * Mathf.Rad2Deg;
        //return angle <= fov * 0.5f;

        // We can compare a . b to cos(x) instead of solving for x to reduce complexity
        return Vector3.Dot(targetDirection, viewerDirection) > Mathf.Cos(Mathf.Deg2Rad * fov * 0.5f);
    }

    public static bool InRangeDebug(Transform viewer, Transform target, float length, float fov)
    {
        Vector3 front = viewer.transform.rotation.eulerAngles;
        Vector3 left = front;
        Vector3 right = front;
        Quaternion ql = new Quaternion();
        Quaternion qr = new Quaternion();
        left.y -= fov * 0.5f;
        right.y += fov * 0.5f;
        ql.eulerAngles = left;
        qr.eulerAngles = right;

        Color color = InRange(viewer, target, length, fov) ? Color.red : Color.green;
        Debug.DrawLine(viewer.position, viewer.position + ql * Vector3.forward * length, color);
        Debug.DrawLine(viewer.position, viewer.position + qr * Vector3.forward * length, color);
        return color == Color.red;
    }

    
    public static float CalculateInterpolation(InterpolationBase interpolation, float origin, float end, float t)
    {
        float y = 0.0f;
        switch (interpolation.interpolationType)
        {
            case Interpolation.LINEAR:
            {
                y = Mathf.Lerp(origin, end, t);
            }
                break;

            case Interpolation.SMOOTH:
            {
                y = Mathf.SmoothStep(origin, end, t);
            }
                break;
            
            case Interpolation.EASE:
            {
                float t1 = easings[(int)interpolation.easingType](t);
                y = Mathf.LerpUnclamped(origin, end, t1);
            }
                break;

            case Interpolation.CURVE:
            {
                float t1 = interpolation.animationCurve.Evaluate(t);
                y = Mathf.LerpUnclamped(origin, end, t1);
            }
                break;

        }

        return y;
    }
    
    public delegate float EasingMethod(float t);
    
    public static EasingMethod[] easings = new EasingMethod[9]
    {
        Utility.EaseSine,
        Utility.EaseQuadratic,
        Utility.EaseCubic,
        Utility.EaseQuartic,
        Utility.EaseQuintic,
        Utility.EaseExponential,
        Utility.EaseCircle,
        Utility.EaseBack,
        Utility.EaseElastic
    };
    
    public static float EaseSine(float t)
    {
        return -(Mathf.Cos(Mathf.PI * t) - 1.0f) / 2.0f;
    }

    public static float EaseQuadratic(float t)
    {
        return t < 0.5f ? 2.0f * t * t : 1 - Mathf.Pow(-2.0f * t + 2.0f, 2.0f) / 2.0f;
    }

    public static float EaseCubic(float t)
    {
        return t < 0.5f ? 4.0f * t * t * t : 1.0f - Mathf.Pow(-2.0f * t + 2.0f, 3.0f) / 2.0f;
    }

    public static float EaseQuartic(float t)
    {
        return t < 0.5f ? 8.0f * t * t * t * t : 1.0f - Mathf.Pow(-2.0f * t + 2.0f, 4.0f) / 2.0f;
    }

    public static float EaseQuintic(float t)
    {
        return t < 0.5f ? 16.0f * t * t * t * t * t : 1.0f - Mathf.Pow(-2.0f * t + 2.0f, 5.0f) / 2.0f;
    }

    public static float EaseExponential(float t)
    {
        return t == 0.0f
          ? 0.0f
          : t == 1.0f
          ? 1.0f
          : t < 0.5f ? Mathf.Pow(2.0f, 20.0f * t - 10.0f) / 2.0f
          : (2.0f - Mathf.Pow(2.0f, -20.0f * t + 10.0f)) / 2.0f;
    }

    public static float EaseCircle(float t)
    {
        return t < 0.5f
          ? (1.0f - Mathf.Sqrt(1.0f - Mathf.Pow(2.0f * t, 2.0f))) / 2.0f
          : (Mathf.Sqrt(1.0f - Mathf.Pow(-2.0f * t + 2.0f, 2.0f)) + 1.0f) / 2.0f;
    }

    public static float EaseBack(float t)
    {
        const float c1 = 1.70158f;
        const float c2 = c1 * 1.525f;

        return t < 0.5
          ? (Mathf.Pow(2.0f * t, 2.0f) * ((c2 + 1.0f) * 2.0f * t - c2)) / 2.0f
          : (Mathf.Pow(2.0f * t - 2.0f, 2.0f) * ((c2 + 1.0f) * (t * 2.0f - 2.0f) + c2) + 2.0f) / 2.0f;
    }

    public static float EaseElastic(float t)
    {
        const float c5 = (2.0f * Mathf.PI) / 4.5f;

        return t == 0.0f
          ? 0.0f
          : t == 1.0f
          ? 1.0f
          : t < 0.5f
          ? -(Mathf.Pow(2.0f, 20.0f * t - 10.0f) * Mathf.Sin((20.0f * t - 11.125f) * c5)) / 2.0f
          : (Mathf.Pow(2.0f, -20.0f * t + 10.0f) * Mathf.Sin((20.0f * t - 11.125f) * c5)) / 2.0f + 1.0f;
    }
}
