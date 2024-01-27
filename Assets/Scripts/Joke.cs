
using System;

[Serializable]
public class Joke
{
    public Topic topic;
    
    public Joke(Topic topic)
    {
        this.topic = topic;
    }
}