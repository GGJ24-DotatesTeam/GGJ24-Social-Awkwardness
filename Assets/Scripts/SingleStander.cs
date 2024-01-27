using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStander : MonoBehaviour
{
    public Topic knownTopic;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedSingleStander = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedSingleStander = null;
        }
    }
}
