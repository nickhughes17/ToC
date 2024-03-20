using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayedCardTextDisplay : MonoBehaviour
{
    [SerializeField] TMP_Text playedText;
    public float fadeTime;
    private float alphaValue;
    private float fadeAwayPerSecond;
    // Start is called before the first frame update
    void Start()
    {
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = playedText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if(fadeTime > 0){
            fadeTime -= Time.deltaTime;
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            playedText.color = new Color(playedText.color.r, playedText.color.g, playedText.color.b, alphaValue);
        }
    }

    public void DisplayPlayedCard(CardSO card){
        playedText.text = card.name + " played";
        fadeTime = 1f;
        alphaValue = 1;
    }
}
