using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStander : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SingleStander: OnTriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("SingleStander: OnTriggerExit");
    }
}
