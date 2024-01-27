using System;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    public Topic conversationTopic;
    public bool isTopicKnownToPlayer = false;
    public float timeSpentByPlayerLearningTopic = 0f;
    
    private ProgressBar _progressBar;
    private TopicIcon _topicIcon;
    private PlayerTopicListener _playerTopicListener;

    private void Start()
    {
        _topicIcon = GetComponentInChildren<TopicIcon>();
        _progressBar = GetComponentInChildren<ProgressBar>();
        _playerTopicListener = GameObject.Find("/Player/PlayerTopicListener").GetComponent<PlayerTopicListener>();
    }
    
    private void Update()
    {
        if (!isTopicKnownToPlayer)
        {
            _progressBar.SetProgress(timeSpentByPlayerLearningTopic / _playerTopicListener.topicLearningTime);
        }
    }

    public void UpdateTopicIcon()
    {
        _topicIcon.SetTopic(conversationTopic);
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
