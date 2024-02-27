using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayedController : MonoBehaviour
{
    [SerializeField] private HazardController hazardController;
    [SerializeField] private SqueakController squeakController;
    [SerializeField] private TreasureController treasureController;
    [SerializeField] private TunaController tunaController;

    public void PlayCard(CardSO card)
    {
        switch (card.attributeToAffect)
        {
            //===================================================================HAZARD
            case "Hazard":

                switch (card.name)
                {
                    //==============================Hazard Halt
                    case "Hazard Halt":
                        hazardController.blockQueue += card.amountToAffect;
                        Debug.Log("HAZARD HALT PLAYED. " + hazardController.blockQueue + " hazard block remaining.");
                        break;
                }
                break;

            //===================================================================SQUEAK
            case "Squeak":

                switch (card.name)
                {
                    //==============================Stealthy Stride
                    case "Stealthy Stride":
                        if (squeakController.currentSqueak - card.amountToAffect >= 0)
                        {
                            Debug.Log("STEALTHY STRIDE PLAYED. Squeak Reduced by: " + card.amountToAffect);
                            squeakController.currentSqueak -= card.amountToAffect;
                        }
                        else
                        {
                            Debug.Log("STEALTHY STRIDE PLAYED. Squeak Reduced to: 0");
                            squeakController.currentSqueak = 0;
                        }
                        break;
                }
                break;

            //===================================================================TREASURE
            case "Treasure":

                switch (card.name)
                {
                    //==============================Treasure Trove
                    case "Treasure Trove":
                        treasureController.totalTime += (float)card.amountToAffect;
                        Debug.Log("TREASURE TROVE PLAYED. Total treasure drop time queued up: " + treasureController.totalTime);
                    break;
                }
                break;

            //===================================================================TUNA
            case "Tuna":
                // card affects tuna
                break;


            default:
                break;
        }
    }
}
