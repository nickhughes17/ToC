using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TreasureController : MonoBehaviour
{
    public float spawnTime = 1f;
    public float spawnChance = 1f;
    private float _totalTime = 0f; // Total time to run the spawning coroutine
    public float totalTime
    {
        get { return _totalTime; }
        set
        {
            _totalTime = value;
            OnTotalTimeChanged?.Invoke(value);
        }
    }

    // Event to notify listeners when totalTime changes
    public event Action<float> OnTotalTimeChanged;
}
