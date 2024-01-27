using UnityEngine;

public class PlayerJokeLearner : MonoBehaviour
{
    public SingleStander joinedSingleStander = null;

    public float jokeLearningTime = 3f;
    
    private float currentJokeLearningTime = 0f;
    
    private PlayerJoker _playerJoker; //Holds the reference to the PlayerJoker component, used to communicate with it
    void Start()
    {
        _playerJoker = GetComponent<PlayerJoker>();
    }
    
    void Update()
    {
        if(joinedSingleStander == null || joinedSingleStander.isInCooldown)
        {
            currentJokeLearningTime = 0f;
            return;
        }
        
        currentJokeLearningTime += Time.deltaTime;
        if(currentJokeLearningTime >= jokeLearningTime) 
        { 
            currentJokeLearningTime = 0f; 
            LearnJoke(joinedSingleStander.knownTopic);
        }
    }

    private void LearnJoke(Topic topic)
    {
        Debug.Log($"Learned joke in topic {topic}");
        joinedSingleStander.isInCooldown = true;
        _playerJoker.AddJokeFromTopic(joinedSingleStander.knownTopic);
    }
}
