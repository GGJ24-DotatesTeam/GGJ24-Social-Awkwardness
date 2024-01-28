using System;
using DG.Tweening;
using UnityEngine;

public class Huddle : MonoBehaviour
{
    public Topic conversationTopic;
    public bool isTopicKnownToPlayer = false;
    public float timeSpentByPlayerLearningTopic = 0f;
    
    private ProgressBar _progressBar;
    private TopicIcon _topicIcon;
    private PlayerTopicListener _playerTopicListener;
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
        _topicIcon = GetComponentInChildren<TopicIcon>();
        _progressBar = GetComponentInChildren<ProgressBar>();
        _playerTopicListener = GameObject.Find("/Player/PlayerTopicListener").GetComponent<PlayerTopicListener>();
    }
    
    private void Update()
    {
        UpdateTopicIcon();
        if (!isTopicKnownToPlayer)
        {
            _progressBar.SetProgress(timeSpentByPlayerLearningTopic / _playerTopicListener.topicLearningTime);
        }
    }

    public void UpdateTopicIcon()
    {
        if(isTopicKnownToPlayer)
            _topicIcon.SetTopic(conversationTopic);
        else
        {
            _topicIcon.SetTopic(Topic.None);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedHuddle = this;
        }
    }
    
    public void PlayParticles()
    {
        _particleSystem.Play();
        
        DOVirtual.DelayedCall(1f, () =>
        {
            _particleSystem.Stop();
        });
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<PlayerJoker>(out var playerJoker))
        {
            playerJoker.joinedHuddle = null;
        }
    }
}
