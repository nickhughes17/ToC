using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckDisplay : MonoBehaviour
{
    [SerializeField] private CardInventory cardInventory;
    private List<CardSO> cards;

    public GameObject cardPrefab;
    public Transform gridParent; // Parent transform with GridLayoutGroup component

    public void CreateCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject cardGO = Instantiate(cardPrefab, gridParent);
            CardDisplay cardDisplay = cardGO.GetComponent<CardDisplay>();
            cardDisplay.card = cards[i];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cards = cardInventory.GetDeck();
        CreateCards();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
