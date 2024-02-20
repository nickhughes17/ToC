using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseCardButton : MonoBehaviour
{
    public CardSO cardToBuy;
    private Inventory inv;

    private void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    public void PurchaseCard() {
        // TODO: CHECK IF THEY HAVE THE RIGHT NUMBER OF TREASURE
        //TODO: ADD CARD PURCHASED TO CARD INVENTORY
        int priceOfCard = 0 - cardToBuy.price;
        inv.IncrementTreasures(priceOfCard);
    }
}
