using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DeckSO : ScriptableObject
{
    public List<CardSO> cards;

    public void AddCardToDeck(CardSO card)
    {
        cards.Add(card);
    }
}