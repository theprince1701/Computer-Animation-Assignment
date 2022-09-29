using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    delegate float EasingMethod(float t);
    EasingMethod[] easings = new EasingMethod[9]
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

    [SerializeField] GameObject target;
    [SerializeField] const float fov = 60.0f;
    [SerializeField] const float length = 10.0f;
    [SerializeField] const float rotationAmount = 90.0f;
    [SerializeField] const float rotationDuration = 3.0f;
    [SerializeField] Interpolation interpolation = Interpolation.LINEAR;
    [SerializeField] Easing easing = Easing.SINE;
    [SerializeField] AnimationCurve curve;

    private float rotSrc, rotDst;
    private float elapsedTime = 0.0f;
    private bool right = true;

    void Start()
    {
        rotSrc = transform.rotation.eulerAngles.y;
        rotDst = rotSrc + rotationAmount;
    }

    void Update()
    {
        float y = 0.0f;
        float t = right ? elapsedTime / rotationDuration : 1.0f - elapsedTime / rotationDuration;
        switch (interpolation)
        {
            case Interpolation.LINEAR:
                {
                    y = Mathf.Lerp(rotSrc, rotDst, t);
                }
                break;

            case Interpolation.SMOOTH:
                {
                    y = Mathf.SmoothStep(rotSrc, rotDst, t);
                }
                break;

            case Interpolation.EASE:
                {
                    float t1 = easings[(int)easing](t);
                    y = Mathf.LerpUnclamped(rotSrc, rotDst, t1);
                }
                break;

            case Interpolation.CURVE:
                {
                    float t1 = curve.Evaluate(t);
                    y = Mathf.LerpUnclamped(rotSrc, rotDst, t1);
                }
                break;
        }

        Vector3 euler = transform.eulerAngles;
        euler.y = y;
        transform.eulerAngles = euler;
        Utility.InRangeDebug(transform, target.transform, length, fov);

        elapsedTime += Time.smoothDeltaTime;
        if (elapsedTime > rotationDuration)
        {
            elapsedTime = 0.0f;
            right = !right;
        }
    }
}
