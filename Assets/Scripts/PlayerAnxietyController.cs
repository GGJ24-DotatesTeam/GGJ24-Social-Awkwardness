using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnxietyController : MonoBehaviour
{
    [SerializeField] 
    private ProgressBar _anxietyBar;
    public float currentAnxiety = 50f;
    
    public float passiveAnxietyIncreaseRate = 1f;
    public float failedJokeAnxietyIncrease = 10f;
    public float successfulJokeAnxietyDecrease = 20f;
    
    public void IncreaseAnxiety()
    {
        currentAnxiety += failedJokeAnxietyIncrease;
    }

    public void DecreaseAnxiety()
    {
        currentAnxiety -= successfulJokeAnxietyDecrease;
    }

    private void Update()
    {
        currentAnxiety += passiveAnxietyIncreaseRate * Time.deltaTime;
        _anxietyBar.SetProgress(currentAnxiety / 100f);
    }
}
