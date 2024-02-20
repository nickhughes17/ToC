using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardSO card;
    public TMP_Text nameText;
    public TMP_Text descText;
    public Image artworkImage;
    public Image directionalIcon;
    public Image attributeIcon;
    public TMP_Text priceText;


    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.name;
        descText.text = card.description;
        artworkImage.sprite = card.artwork;
        directionalIcon.sprite = card.directionIcon;
        attributeIcon.sprite = card.attributeIcon;
        if (priceText != null)
        {
            priceText.text = card.price.ToString();
        }
    }
}
