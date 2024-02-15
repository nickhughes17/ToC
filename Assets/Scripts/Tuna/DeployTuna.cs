using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployTuna : MonoBehaviour
{
    [SerializeField] private GameObject tunaPrefab;
    [SerializeField] private TunaController tunaController;
    [SerializeField] private float spawnLocationX;
    [SerializeField] private float spawnLocationY;
    System.Random rnd = new System.Random();
    [SerializeField] private float distanceFromSpawnLocation;

    void Start()
    {
        StartCoroutine(TunaWave());
    }

    private void SpawnTuna()
    {
        int val = rnd.Next(1, 100);
        if (val <= tunaController.spawnChance)
        {
            GameObject newTuna = Instantiate(tunaPrefab) as GameObject;
            newTuna.transform.position = new Vector2(spawnLocationX + Random.Range(-1.0f, 1.0f),
                    spawnLocationY + Random.Range(-1.0f, 1.0f));
        }
    }

    IEnumerator TunaWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(tunaController.spawnTime);
            SpawnTuna();
        }
    }
}
