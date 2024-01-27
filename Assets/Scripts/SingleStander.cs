using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStander : MonoBehaviour
{
    public Topic knownTopic;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SingleStander: OnTriggerEnter");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("SingleStander: OnTriggerExit");
    }
}
