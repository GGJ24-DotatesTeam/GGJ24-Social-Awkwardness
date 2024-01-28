using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopicIcon : MonoBehaviour
{
    [SerializeField] private Sprite _questionMarkSprite;
    [SerializeField] private Sprite _yellowTopicSprite;
    [SerializeField] private Sprite _blueTopicSprite;
    [SerializeField] private Sprite _redTopicSprite;
    [SerializeField] private Sprite _brownTopicSprite;
    [SerializeField] private Sprite _greenTopicSprite;
    
    [SerializeField] private Image _image;
    
    private Dictionary<Topic, Sprite> _topicSpriteDict = new Dictionary<Topic, Sprite>();
    
    private TextMeshProUGUI _text;
    
    void Awake()
    {
        _topicSpriteDict.Add(Topic.None, _questionMarkSprite);
        _topicSpriteDict.Add(Topic.Yellow, _yellowTopicSprite);
        _topicSpriteDict.Add(Topic.Blue, _blueTopicSprite);
        _topicSpriteDict.Add(Topic.Red, _redTopicSprite);
        _topicSpriteDict.Add(Topic.Brown, _brownTopicSprite);
        _topicSpriteDict.Add(Topic.Green, _greenTopicSprite);
    }
    
    public void SetTopic(Topic topic)
    {
        _image.sprite = _topicSpriteDict[topic];
    }
    
}
