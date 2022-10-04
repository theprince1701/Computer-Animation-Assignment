using System;
using UnityEngine;


public class PlayerInterpolation : InterpolationManager
{
    [SerializeField] private InterpolationProperties[] interpolationProperties;
    
    private int _currentInterpolationIndex = -1;
    
    
    private void EnterInterpolation(int index)
    {
        if (index == -1)
            return;

        InterpolationProperties properties = interpolationProperties[index];

        CustomPositionInterpolation positionInterpolation = InterpolationTransitions.GetInterpolationPosition(properties.interpolation, properties.easing);
        CustomRotationInterpolation rotationInterpolation = InterpolationTransitions.GetInterpolationRotation(properties.interpolation, properties.easing);
        
        SetPose(properties.position, positionInterpolation, Quaternion.Euler(properties.rotation),
            rotationInterpolation, properties.scale, positionInterpolation, properties.time);
    }

    public void ExitInterpolation()
    {
        if (_currentInterpolationIndex == -1)
            return;
        
        InterpolationProperties properties = interpolationProperties[_currentInterpolationIndex];

        CustomPositionInterpolation positionInterpolation = InterpolationTransitions.GetInterpolationPosition(properties.interpolation, properties.easing);
        CustomRotationInterpolation rotationInterpolation = InterpolationTransitions.GetInterpolationRotation(properties.interpolation, properties.easing);
        
        ResetPose(properties.position, positionInterpolation, rotationInterpolation, properties.scale, 
            positionInterpolation, properties.time);
    }

    private void Update()
    {
        UpdateInterpolation();
    }

    public void SetInterpolation(string interpolationID)
    {
        int newIndex = GetInterpolationIndex(interpolationID);

        if (_currentInterpolationIndex != -1)
        {
            ExitInterpolation();
            _currentInterpolationIndex = -1;
        }
        
        if (_currentInterpolationIndex != newIndex)
        {
            _currentInterpolationIndex = newIndex;
            EnterInterpolation(newIndex);
        }
    }

    public int GetInterpolationIndex(string id)
    {
        for (int i = 0; i < interpolationProperties.Length; i++)
        {
            if (interpolationProperties[i].id == id)
            {
                return i;
            }
        }

        return -1;
    }
}
