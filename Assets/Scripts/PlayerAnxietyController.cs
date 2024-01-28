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

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    private void Awake()
    {
        _winPanel.SetActive(false);
        _losePanel.SetActive(false);
    }

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
        
        if(currentAnxiety >= 100f)
        {
            _losePanel.SetActive(true);
        }
        else if(currentAnxiety <= 0f)
        {
            _winPanel.SetActive(true);
        }
    }
}
