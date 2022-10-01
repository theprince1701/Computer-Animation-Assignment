using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleManager : MonoBehaviour
{
    [SerializeField] private Example[] examples;

    private int _currentExampleIndex;

    private void Awake()
    {
        DisableAllExamples();
        examples[_currentExampleIndex].EnterExample();
    }

    public void NextExample()
    {
        _currentExampleIndex++;

        if (_currentExampleIndex >= examples.Length)
            _currentExampleIndex = 0;
        
        DisableAllExamples();
        examples[_currentExampleIndex].EnterExample();
    }

    public void PreviousExample()
    {
        if (_currentExampleIndex < 0)
            _currentExampleIndex = examples.Length - 1;
        
        DisableAllExamples();
        examples[_currentExampleIndex].EnterExample();
    }

    private void DisableAllExamples()
    {
        for (int i = 0; i < examples.Length; i++)
        {
            examples[i].ExitExample();
        }
    }
}
