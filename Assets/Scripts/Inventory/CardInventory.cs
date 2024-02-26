using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    [SerializeField] private DeckSO deck;

    public void AddCardToInventory(CardSO cardToAdd)
    {
        deck.AddCardToDeck(cardToAdd);
        Debug.Log(cardToAdd.name + " Added to Deck");
    }

    public List<CardSO> GetDeck(){
        return deck.cards;
    }


}
