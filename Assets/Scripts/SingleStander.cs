using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SingleStander : MonoBehaviour
{
    public bool isTopicKnownToPlayer = false;
    public Topic knownTopic;
    public float jokeTeachingCooldown = 5f;
    private float _timeSinceLastJokeTeaching = 0f;
    public bool isInCooldown = false;
    public float timeSpentByPlayerLearningTopic = 0f;
    
    private ProgressBar _progressBar;
    private PlayerTopicListener _playerTopicListener;
    
    private void Awake()
    {
        _progressBar = GetComponentInChildren<ProgressBar>();
        _playerTopicListener = GameObject.Find("/Player/PlayerTopicListener").GetComponent<PlayerTopicListener>();
    }
    
    void Update()
    {
        if(isInCooldown)
        {
            _timeSinceLastJokeTeaching += Time.deltaTime;
            if(_timeSinceLastJokeTeaching >= jokeTeachingCooldown)
            {
                _timeSinceLastJokeTeaching = 0f;
                isInCooldown = false;
            }
        }
        
        if (!isTopicKnownToPlayer)
        {
            _progressBar.SetProgress(timeSpentByPlayerLearningTopic / _playerTopicListener.topicLearningTime);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<PlayerJokeLearner>(out var playerJokeLearner))
        {
            playerJokeLearner.joinedSingleStander = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<PlayerJokeLearner>(out var playerJokeLearner))
        {
            playerJokeLearner.joinedSingleStander = this;
        }
    }
}
