using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JokeButton : MonoBehaviour
{
    public Topic topic;
    [SerializeField]
    private PlayerJoker _playerJoker;

    [SerializeField] 
    private TextMeshProUGUI _buttonText;
    
    [SerializeField]
    private Button _button;
    
    [SerializeField]
    private TopicIcon _topicIcon;

    private void Start()
    {
        _topicIcon.SetTopic(topic);
        UpdateText();
    }

    private void UpdateText()
    {
        if (_playerJoker.JokeInTopicCountDict[topic] == 0)
        {
            _buttonText.text = "";
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
            _buttonText.text = "x" +_playerJoker.JokeInTopicCountDict[topic].ToString();
        }
    }
    
    public void TellJoke()
    {
        _playerJoker.TellJoke(topic);
        UpdateText();
    }

    private void Update()
    {
        UpdateText();
    }
}
