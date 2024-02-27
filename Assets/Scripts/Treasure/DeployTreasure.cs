using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployTreasure : MonoBehaviour
{
    public GameObject treasurePrefab; // The prefab of the treasure GameObject
    public float spawnLocationX; // X coordinate of the spawn location
    public float spawnLocationY; // Y coordinate of the spawn location
    public float spawnRadius = 5f; // Radius within which treasures will be spawned

    [SerializeField] private TreasureController treasureController;
    private Coroutine spawnCoroutine;

    void Start()
    {
        // Subscribe to the OnTotalTimeChanged event
        treasureController.OnTotalTimeChanged += OnTotalTimeChangedHandler;
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when the GameObject is destroyed
        treasureController.OnTotalTimeChanged -= OnTotalTimeChangedHandler;

        // Stop the coroutine when the GameObject is destroyed
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);
    }

    IEnumerator SpawnTreasuresCoroutine(float totalTime)
    {
        float elapsedTime = 0f;
        while (elapsedTime < totalTime)
        {
            // Generate a random position within the spawn radius
            Vector2 randomPosition = Random.insideUnitCircle * spawnRadius;
            Vector3 spawnPosition = new Vector3(randomPosition.x + spawnLocationX, randomPosition.y + spawnLocationY, 0f);

            // Check if a treasure should be spawned based on spawn chance
            if (Random.value < treasureController.spawnChance)
            {
                // Spawn the treasure at the generated position
                Instantiate(treasurePrefab, spawnPosition, Quaternion.identity);
            }

            // Wait for the specified spawn time
            yield return new WaitForSeconds(treasureController.spawnTime);

            // Update elapsed time
            elapsedTime += treasureController.spawnTime;
        }
    }

    // Method to start or restart the spawning coroutine
    private void StartSpawning(float totalTime)
    {
        // Restart the coroutine
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);

        spawnCoroutine = StartCoroutine(SpawnTreasuresCoroutine(totalTime));
    }

    // Event handler for OnTotalTimeChanged event
    private void OnTotalTimeChangedHandler(float totalTime)
    {
        StartSpawning(totalTime);
    }
}
