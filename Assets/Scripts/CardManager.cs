using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    [SerializeField] Card[] cards;
    [SerializeField] GameObject canvas;
    [SerializeField] float spacing = 100f;
    [SerializeField] float cardYPosition = -500f;

    private List<GameObject> cardsList = new List<GameObject>();



    void Start()
    {
        SpawnCards();
        PlaceCards();
    }

    
    private void PlaceCards()
    {
        float totalWidth = (cardsList.Count - 1) * spacing;
        float startX = -totalWidth / 2;

        for (int i = 0; i < cardsList.Count; i++)
        {
            Vector3 position = new Vector3(startX + i * spacing, cardYPosition, 0);

            cardsList[i].transform.localPosition = position;
            cardsList[i].transform.localScale = Vector3.one;
            cardsList[i].transform.localRotation = Quaternion.identity;
        }
    }

    void SpawnCards()
    {
        if (cards.Length > 0)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                GameObject cardInstance = Instantiate(cards[i].cardPrefab, canvas.transform);
                cardsList.Add(cardInstance);
                SetCardTest(cardInstance, cards[i]);
            }
        }
    }

    private void SetCardTest(GameObject cardObject, Card card)
    {
        TextMeshProUGUI questionText = cardObject.transform.Find("QuestionText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI answerText = cardObject.transform.Find("JokeText").GetComponent<TextMeshProUGUI>();

        if (questionText != null && answerText != null)
        {
            questionText.text = card.jokeQuestion;
            answerText.text = card.jokeAnswer;
        }
        else
        {
            Debug.LogError("TextMeshPro components not found in the card prefab.");
        }

    }

}
