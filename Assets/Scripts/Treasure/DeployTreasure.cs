using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployTreasure : MonoBehaviour
{
    [SerializeField] private GameObject treasurePrefab;
    [SerializeField] private TreasureController treasureController;
    [SerializeField] private float spawnLocationX;
    [SerializeField] private float spawnLocationY;
    System.Random rnd = new System.Random();
    [SerializeField] private float distanceFromSpawnLocation;
    private float totalTime = 0f;
    private Coroutine coroutineInstance;

    private void SpawnTreasure()
    {
        int val = rnd.Next(1, 100);
        if (val <= treasureController.spawnChance)
        {
            GameObject newTreasure = Instantiate(treasurePrefab) as GameObject;
            newTreasure.transform.position = new Vector2(spawnLocationX + Random.Range(-1.0f, 1.0f),
                    spawnLocationY + Random.Range(-1.0f, 1.0f));
        }
    }

    private IEnumerator RunStackingCoroutine(float duration)
    {
        float remainingTime = duration;

        // Run the coroutine until remaining time is zero
        while (remainingTime > 0f)
        {

            // Update the total time elapsed
            totalTime += Time.deltaTime;

            // Update remaining time for this frame
            remainingTime -= Time.deltaTime;

            yield return new WaitForSeconds(treasureController.spawnTime);
            SpawnTreasure();

            // Wait for the end of the frame
            yield return null;
        }
    }

    // IEnumerator TreasureWave(float )
    // {
    //     float remainingTime = duration;
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(treasureController.spawnTime);
    //         SpawnTreasure();
    //     }
    // }

    public void StartTreasureDropCoroutine(float duration)
    {
        if (coroutineInstance != null)
            StopCoroutine(coroutineInstance); // Stop the previous coroutine instance

        coroutineInstance = StartCoroutine(RunStackingCoroutine(duration));
    }

}
