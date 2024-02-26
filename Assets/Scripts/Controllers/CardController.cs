using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardController : MonoBehaviour
{
    public static CardController instance { get; private set; }
    private CardInventory cardInv;
    [SerializeField] private CardPlayedController cardPlayedController;
    public float timeBeforeFirstDraw = 0f;
    //how fast cards draw
    public float drawRate;
    //how often to roll for a card draw
    public float drawInterval;
    public TMP_Text numberOfCards;
    private List<CardSO> deckForThisRun;


    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        InvokeRepeating("DrawCard", timeBeforeFirstDraw, drawRate);
    }

    void Start()
    {
        cardInv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<CardInventory>();
        List<CardSO> deckCpy = cardInv.GetDeck();
        List<CardSO> newDeck = new List<CardSO>(deckCpy);
        deckForThisRun = newDeck;
    }

    void Update()
    {
        int numCards = deckForThisRun.Count;
        numberOfCards.text = numCards.ToString();

        if (numCards <= 0)
        {
            CancelInvoke("DrawCard");
        }
    }

    private void DrawCard()
    {
        //choose a random card in the deck, play it, remove it from deckForThisRun.
        int randomIdx = Random.Range(0, deckForThisRun.Count);
        CardSO selected = deckForThisRun[randomIdx];
        deckForThisRun.RemoveAt(randomIdx);
        PlayCard(selected);
    }

    private void PlayCard(CardSO cardToPlay)
    {
        string attributeToAffect = cardToPlay.attributeToAffect;
        int numToAffect = cardToPlay.amountToAffect;
        cardPlayedController.PlayCard(cardToPlay);
    }
}
