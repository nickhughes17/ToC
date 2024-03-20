using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HazardController : MonoBehaviour
{
    public static HazardController instance { get; private set; }
    public int currentHazard;
    public float timeBeforeFirstTick = 0f;
    //how fast hazard chance ticks up
    public float tickRate;
    //how much hazard chance ticks up
    public int amountPerTick;
    //how often to roll for a hazard tick
    public float rollInterval;
    private float timer = 0f;
    public TMP_Text amountDisplay;
    public List<Vector2> wallLocations;
    [SerializeField] private GameObject wallPrefab;
    private bool maxHazardReached = false;
    public int blockQueue = 0;


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

    void Start()
    {
        amountDisplay.text = currentHazard.ToString("0");
    }

    void Update()
    {
        amountDisplay.text = currentHazard.ToString("0");
        timer += Time.deltaTime;
        if (timer >= rollInterval && maxHazardReached != true)
        {
            RollForHazardTick();
            timer = 0f;
        }

        if (maxHazardReached == true)
        {
            CancelInvoke("TickHazard");
        }
    }

    private void TickHazard()
    {
        currentHazard += amountPerTick;
    }

    private void RollForHazardTick()
    {
        // (1*currentHazard) / 100 chance to tick a wall up per Roll.
        //1/100 = 0.01f
        double baseChance = 0.01;
        double chanceToHit = baseChance * currentHazard;
        double randomValue = Random.value;

        if (randomValue <= chanceToHit)
        {
            if (blockQueue == 0)
            {
                RaiseHazardWall();
            }
            else
            {
                blockQueue -= 1;
                Debug.Log("Hazard BLOCKED. Remaining Haz Block: " + blockQueue);
            }
            //raise a random hazard wall
            //reset hazard to 0
            currentHazard = 0;
        }
    }

    private void RaiseHazardWall()
    {
        if (wallLocations.Count == 0)
        {
            maxHazardReached = true;
        }
        else
        {
            int randomIdx = Random.Range(0, wallLocations.Count);
            Vector2 selected = wallLocations[randomIdx];
            wallLocations.RemoveAt(randomIdx);
            GameObject newWall = Instantiate(wallPrefab) as GameObject;
            newWall.transform.position = new Vector2(selected.x, selected.y);
        }
    }
}
