using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
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
    Dictionary<Topic, int> _jokeInTopicCountDict = new Dictionary<Topic, int>();
    
    private void Awake()
    {
        // Initialize the dictionary of topic extra landing chances
        foreach(Topic topic in Enum.GetValues(typeof(Topic)))
        {
            _topicExtraLandingChanceDict.Add(topic, 0.0f);
        }
        
        // Initialize the dictionary of joke in topic counts with 0.0f
        foreach(Topic topic in Enum.GetValues(typeof(Topic)))
        {
            _jokeInTopicCountDict.Add(topic, 0);
        }
        foreach (Joke joke in jokes)
        {
            _jokeInTopicCountDict[joke.topic]++;
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
    
    [Button]
    public void TellJoke(Topic topic)
    {
        if(_jokeInTopicCountDict[topic] == 0)
        {
            Debug.Log($"No jokes in topic {topic}");
            return;
        }
        
        if(joinedHuddle == null)
        {
            Debug.Log($"No one to tell joke to");
            return;
        }
        
        RemoveJokeFromTopic(topic);
        if(TryJokeLanding(topic, joinedHuddle.conversationTopic))
        {
            Debug.Log($"Joke landed");
        }
        else
        {
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
        
        _jokeInTopicCountDict[topic]--;
    }
    
    public void AddJokeFromTopic(Topic topic)
    {
        jokes.Add(new Joke(topic));
        _jokeInTopicCountDict[topic]++;
    }
}
