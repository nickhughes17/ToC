using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HazardController : MonoBehaviour
{
    public static HazardController instance { get; private set; }
    public float currentHazard;

    public float timeBeforeFirstTick = 0f;
    //how fast hazard chance ticks up
    public float tickRate;
    //how much hazard chance ticks up
    public float amountPerTick;
    //how often to roll for a hazard tick
    public float rollInterval;
    private float timer = 0f;
    public TMP_Text amountDisplay;
    public List<Vector2> wallLocations;
    [SerializeField] private GameObject wallPrefab;
    private bool maxHazardReached = false;
    

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
        InvokeRepeating("TickHazard", timeBeforeFirstTick, tickRate);
    }

    void Start(){
        amountDisplay.text = currentHazard.ToString("0");
    }

    void Update(){
        amountDisplay.text = currentHazard.ToString("0");
        timer += Time.deltaTime;
        if(timer >= rollInterval && maxHazardReached != true){
            RollForHazardTick();
            timer = 0f;
        }

        if(maxHazardReached == true){
            CancelInvoke("TickHazard");
        }
    }

     private void TickHazard() {
        currentHazard += amountPerTick;
    }

    private void RollForHazardTick() {
        // (1*currentHazard) / 100 chance to tick a wall up per Roll.
        //1/100 = 0.01f
        float baseChance = 0.01f;
        float chanceToHit = baseChance * currentHazard;
        float randomValue = Random.value;
        Debug.Log("Rolling for hazard with chance: " + chanceToHit * 100 + "%");

        if(randomValue <= chanceToHit){
            //raise a random hazard wall
            RaiseHazardWall();
        } 
    }

    private void RaiseHazardWall(){
        if(wallLocations.Count == 0){
            Debug.Log("MAX HAZARD REACHED! all walls up!");
            maxHazardReached = true;
        } else {
            int randomIdx = Random.Range(0, wallLocations.Count);
            Vector2 selected = wallLocations[randomIdx];
            wallLocations.RemoveAt(randomIdx);
            Debug.Log("Hazard Wall Raised: " + selected);
            GameObject newWall = Instantiate(wallPrefab) as GameObject;
            newWall.transform.position = new Vector2(selected.x, selected.y);
        }
    }
}
