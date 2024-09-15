using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour {
    public GameObject ePrefab;
    public float spawnDelay = 2f;
    public Vector2 spawnRangeX;
    public Vector2 spawnRangeY;
    void Start() {
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnDelay);
    }
    void SpawnEnemy() {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
        Instantiate(ePrefab, spawnPosition, Quaternion.identity);
    }
}