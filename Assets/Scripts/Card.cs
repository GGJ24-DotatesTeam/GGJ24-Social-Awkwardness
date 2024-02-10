using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public GameObject cardPrefab;
    [TextArea]
    public string jokeQuestion;
    [TextArea]
    public string jokeAnswer;
}
