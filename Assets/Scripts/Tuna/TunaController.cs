using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaController : MonoBehaviour
{
    public float spawnTime { get; set; }
    public float spawnChance;

    public void ChangeSpawnChance(int value)
    {
        if (spawnChance + value <= 100 && spawnChance + value >= 0)
        {
            spawnChance += value;
        }
    }

    void Start()
    {
        spawnTime = 1.5f;
        spawnChance = 20;
    }
}
