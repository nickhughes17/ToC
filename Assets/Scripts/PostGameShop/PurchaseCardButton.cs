using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCardButton : MonoBehaviour
{
    public CardSO cardToBuy;
    private CardInventory cardInv;
    private Inventory inv;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        cardInv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CardInventory>();
    }

    public void PurchaseCard()
    {
        int priceOfCard = 0 - cardToBuy.price;
        if (inv.GetNumberOfTreasures() + priceOfCard >= 0)
        {
            inv.IncrementTreasures(priceOfCard);
            cardInv.AddCardToInventory(cardToBuy);
        } else {
            Debug.Log("CARD TOO EXPENSIVE");
        }
    }
}
