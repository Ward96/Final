using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTargets();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTargets()
    {
        for (int i = 0; i < 5; i++)
        {
            float randomX = Random.Range(-4f, 4f);
            float randomY = Random.Range(-4f, 4f);

            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
