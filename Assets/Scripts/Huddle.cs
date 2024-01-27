using UnityEngine;

public class Huddle : MonoBehaviour
{
    public Topic conversationTopic;
    public bool isTopicKnownToPlayer = false;
    public float timeSpentByPlayerLearningTopic = 0f;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedHuddle = this;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedHuddle = null;
        }
    }
}
