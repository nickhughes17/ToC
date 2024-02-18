using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStealthUI : MonoBehaviour
{

    [SerializeField] private FieldOfView fieldOfView;
    [SerializeField] private Canvas uiCanvas;
    [SerializeField] private AIMovement enemy;
    [SerializeField] private Slider slider;
    [SerializeField] private Image playerSeenImage;
    [SerializeField] private Image playerSeenImageRendered;
    private Vector3 offset;
    public bool isChasing = false;
    public Vector3 startingOffset;

    void Start()
    {
        offset = startingOffset;
        playerSeenImageRendered = Instantiate(playerSeenImage, uiCanvas.transform).GetComponent<Image>();
        playerSeenImageRendered.rectTransform.sizeDelta = new Vector2(70, 50);
    }


    void Update()
    {
        if (fieldOfView.playerSeen)
        {
            offset = new Vector3(0, 1.5f, 0);
            playerSeenImageRendered.gameObject.SetActive(true);
        }
        else
        {
            playerSeenImageRendered.gameObject.SetActive(false);

        }
        playerSeenImageRendered.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset);
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.position + offset / 1.5f);

        if (isChasing)
        {
            slider.gameObject.SetActive(true);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }
    }

    public void SetChaseProgress(int progress)
    {
        slider.value = progress;
    }
}
