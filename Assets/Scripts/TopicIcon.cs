using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TopicIcon : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void SetTopic(Topic topic)
    {
        _text.text = topic.ToString();
    }
    
}
