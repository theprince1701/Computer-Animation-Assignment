using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private string exampleName;
   // [SerializeField] private GameObject exampleInfo;

    public void EnterExample()
    {
        gameObject.SetActive(true);
   //     exampleInfo.SetActive(true);
    }

    public void ExitExample()
    {
        gameObject.SetActive(false);
    //    exampleInfo.SetActive(false);
    }
}
