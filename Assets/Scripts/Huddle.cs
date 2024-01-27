using System;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    public Topic conversationTopic;
    public bool isTopicKnownToPlayer = false;
    public float timeSpentByPlayerLearningTopic = 0f;
    
    private ProgressBar _progressBar;
    private PlayerTopicListener _playerTopicListener;

    private void Update()
    {
        if (!isTopicKnownToPlayer)
        {
            _progressBar.SetProgress(timeSpentByPlayerLearningTopic / _playerTopicListener.topicLearningTime);
        }
    }

    private void Start()
    {
        _progressBar = GetComponentInChildren<ProgressBar>();
        _playerTopicListener = GameObject.Find("/Player/PlayerTopicListener").GetComponent<PlayerTopicListener>();
    }
    
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
