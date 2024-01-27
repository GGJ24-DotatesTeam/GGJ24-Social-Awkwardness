using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerTopicListener: MonoBehaviour
{
    public float topicLearningTime = 5f;
    public float radius = 5f;
    
    private SphereCollider _sphereCollider; //Holds the reference to the SphereCollider component, used to set its radius
    
    private void Start()
    {
        _sphereCollider = GetComponent<SphereCollider>();
        SetListeningRadius(radius);
    }
    
    private void SetListeningRadius(float radius)
    {
        _sphereCollider.radius = radius;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Huddle>(out var huddle))
        {
            if (huddle.isTopicKnownToPlayer)
            {
                return;
            }

            huddle.timeSpentByPlayerLearningTopic += Time.deltaTime;
            if (huddle.timeSpentByPlayerLearningTopic >= topicLearningTime)
            {
                huddle.isTopicKnownToPlayer = true;
                huddle.UpdateTopicIcon();
            }
        }else if(other.TryGetComponent<SingleStander>(out var singleStander))
        {
            if (singleStander.isTopicKnownToPlayer)
            {
                return;
            }

            singleStander.timeSpentByPlayerLearningTopic += Time.deltaTime;
            if (singleStander.timeSpentByPlayerLearningTopic >= topicLearningTime)
            {
                singleStander.isTopicKnownToPlayer = true;
                singleStander.UpdateTopicIcon();
            }
        }
    }
}