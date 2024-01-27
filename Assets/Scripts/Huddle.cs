using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    public Topic conversationTopic;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Huddle: OnTriggerEnter");
    }
    
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Huddle: OnTriggerExit");
    }
}
