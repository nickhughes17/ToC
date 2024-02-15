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

    void Start()
    {
        StartCoroutine(TreasureWave());
    }

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

    IEnumerator TreasureWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(treasureController.spawnTime);
            SpawnTreasure();
        }
    }
}
