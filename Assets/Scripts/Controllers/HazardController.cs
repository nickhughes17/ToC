using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HazardController : MonoBehaviour
{
    public static HazardController instance { get; private set; }
    public float currentHazard;
    public float hazardRate;
    public TMP_Text hazardDisplay;

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
        InvokeRepeating("TickHazard", 1f, hazardRate);
    }

    void Start(){
        hazardDisplay.text = currentHazard.ToString("0");
    }

    void Update(){
        hazardDisplay.text = currentHazard.ToString("0");
    }

     private void TickHazard() {
        currentHazard += 1;
    }
}
