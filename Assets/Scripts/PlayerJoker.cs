using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerJoker : MonoBehaviour
{
    [SerializeField]
    public List<Joke> jokes;

    public Huddle joinedHuddle = null;
    
    public float jokeLandingBaseChance = 0.4f;
    public float jokeLandingOnTopicExtraChance = 0.2f;
    
    Dictionary<Topic,float> _topicExtraLandingChanceDict = new Dictionary<Topic, float>();
    public Dictionary<Topic, int> JokeInTopicCountDict = new Dictionary<Topic, int>();
    
    private PlayerAnxietyController _playerAnxietyController;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _jokeTellingClip;
    [SerializeField] private AudioClip _jokeLandingClip;
    [SerializeField] private AudioClip _jokeFailingClip;
    
    private void Awake()
    {
        _playerAnxietyController = GetComponent<PlayerAnxietyController>();
        // Initialize the dictionary of topic extra landing chances
        foreach(Topic topic in Enum.GetValues(typeof(Topic)))
        {
            _topicExtraLandingChanceDict.Add(topic, 0.0f);
        }
        
        // Initialize the dictionary of joke in topic counts with 0.0f
        foreach(Topic topic in Enum.GetValues(typeof(Topic)))
        {
            JokeInTopicCountDict.Add(topic, 0);
        }
        foreach (Joke joke in jokes)
        {
            JokeInTopicCountDict[joke.topic]++;
        }
    }
    
    private bool TryJokeLanding(Topic jokeTopic, Topic conversationTopic)
    {
        float chance = jokeLandingBaseChance + _topicExtraLandingChanceDict[jokeTopic];
        
        if(jokeTopic == conversationTopic)
        {
            chance += jokeLandingOnTopicExtraChance;
        }
        
        Debug.Log($"Joke landing chance: {chance}");
        return UnityEngine.Random.value < chance;
    }
    
    public void TellJoke(Topic topic)
    {
        if(JokeInTopicCountDict[topic] == 0)
        {
            Debug.Log($"No jokes in topic {topic}");
            return;
        }
        
        if(joinedHuddle == null)
        {
            Debug.Log($"No one to tell joke to");
            return;
        }
        
        _animator.SetTrigger("tellingJoke");
        
        _audioSource.clip = _jokeTellingClip;
        _audioSource.time = 0.5f;
        _audioSource.Play();
        
        
        JokeInTopicCountDict[topic]--;
        RemoveJokeFromTopic(topic);
        if(TryJokeLanding(topic, joinedHuddle.conversationTopic))
        {
            _playerAnxietyController.DecreaseAnxiety();
            DOVirtual.DelayedCall(1f, () =>
            {
                _audioSource.PlayOneShot(_jokeLandingClip);
                joinedHuddle.PlayParticles();
            });
            
            Debug.Log($"Joke landed");
        }
        else
        {
            _playerAnxietyController.IncreaseAnxiety();
            DOVirtual.DelayedCall(1f, () =>
            {
                _audioSource.PlayOneShot(_jokeFailingClip);
            });
            Debug.Log($"Joke failed");
        }
    }
    
    private void RemoveJokeFromTopic(Topic topic)
    {
        foreach (Joke joke in jokes)
        {
            if(joke.topic == topic)
            {
                jokes.Remove(joke);
                return;
            }
        }
    }
    
    public void AddJokeFromTopic(Topic topic)
    {
        jokes.Add(new Joke(topic));
        JokeInTopicCountDict[topic]++;
    }
}
