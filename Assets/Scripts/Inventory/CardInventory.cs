using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInventory : MonoBehaviour
{
    [SerializeField] private List<CardSO> cardsInInventory;

    public void AddCardToInventory(CardSO cardToAdd)
    {
        cardsInInventory.Add(cardToAdd);
        Debug.Log(cardToAdd.name + " Added to Inventory");
    }

    public int GetNumberOfCards()
    {
        return cardsInInventory.Count;
    }

    public List<CardSO> GetDeck(){
        return cardsInInventory;
    }


}
