using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class InterpolationProperties : ScriptableObject
{
    public string id;

    public bool usePosition;
    public Vector3 position;

    public bool useRotation;
    public Vector3 rotation;

    public bool useScale;
    public Vector3 scale;
    
    
    public float time;

    public Interpolation interpolation;
    public Easing easing;
}
