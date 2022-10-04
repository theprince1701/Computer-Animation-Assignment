using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(InterpolationProperties))]
public class InterpolationPropertiesEditor : Editor
{
    private InterpolationProperties _interpolationProperties;
    
    public override void OnInspectorGUI()
    {
        _interpolationProperties = target as InterpolationProperties;

        _interpolationProperties.id = EditorGUILayout.TextField("Interpolation ID", _interpolationProperties.id);
        _interpolationProperties.time = EditorGUILayout.FloatField("Interpolation Time", _interpolationProperties.time);
        _interpolationProperties.interpolation = (Interpolation)EditorGUILayout.EnumPopup("Interpolation Type", _interpolationProperties.interpolation);

        if (_interpolationProperties.interpolation == Interpolation.EASE)
        {
            _interpolationProperties.easing = (Easing)EditorGUILayout.EnumPopup("Easing Type", _interpolationProperties.easing);
        }
        
        _interpolationProperties.usePosition =
            EditorGUILayout.Toggle("Use Position", _interpolationProperties.usePosition);
        
        if (_interpolationProperties.usePosition)
        {
            _interpolationProperties.position =
                EditorGUILayout.Vector3Field("Interpolation Position", _interpolationProperties.position);
        }
        
        _interpolationProperties.useRotation =
            EditorGUILayout.Toggle("Use Rotation", _interpolationProperties.useRotation);
        
        if (_interpolationProperties.useRotation)
        {
            _interpolationProperties.rotation =
                EditorGUILayout.Vector3Field("Interpolation Rotation", _interpolationProperties.rotation);
        }
        
        _interpolationProperties.useScale =
            EditorGUILayout.Toggle("Use Scale", _interpolationProperties.useScale);
        
        if (_interpolationProperties.useScale)
        {
            _interpolationProperties.scale =
                EditorGUILayout.Vector3Field("Interpolation Scale", _interpolationProperties.scale);
        }
        
        EditorUtility.SetDirty(target);
    }
}
