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
                        Debug.Log("HAZARD HALT PLAYED");
                        hazardController.blockQueue += card.amountToAffect;
                        break;
                }
                break;

            //===================================================================SQUEAK
            case "Squeak":

                switch (card.name)
                {
                    //==============================Stealthy Stride
                    case "Stealthy Stride":
                        Debug.Log("STEALTHY STRIDE PLAYED");
                        if (squeakController.currentSqueak - card.amountToAffect >= 0)
                        {
                            Debug.Log("Squeak Reduced by: " + card.amountToAffect);
                            squeakController.currentSqueak -= card.amountToAffect;
                        }
                        else
                        {
                            Debug.Log("Squeak Reduced to: 0");
                            squeakController.currentSqueak = 0;
                        }
                        break;
                }
                break;

            //===================================================================TREASURE
            case "Treasure":
            
                // switch (card.name)
                // {
                //     //==============================Treasure Trove
                //     case "Treasure Trove":
                //         deployTreasure.StartTreasureDropCoroutine(card.amountToAffect);
                //     break;
                // }
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
