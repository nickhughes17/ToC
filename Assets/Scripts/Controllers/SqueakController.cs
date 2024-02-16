using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SqueakController : MonoBehaviour
{
    public static SqueakController instance { get; private set; }
    public float currentSqueak;
    public TMP_Text squeakDisplay;

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
    }

    void Start(){
        squeakDisplay.text = currentSqueak.ToString("0");
    }
    
    void Update(){
        squeakDisplay.text = currentSqueak.ToString("0");
    }
}
