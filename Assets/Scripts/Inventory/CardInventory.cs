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

    public void PrintNumberOfCards()
    {
        Debug.Log(cardsInInventory.Count);
    }


}
