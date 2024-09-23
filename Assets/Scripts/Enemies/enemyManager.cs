using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemyManager : MonoBehaviour {
    List<enemy> enemies = new List<enemy>();
    float nextEnemySpawn = 0;

    [SerializeField] List<enemy> enemyPrefabs;
    [SerializeField] float enemySpawnRate = 0;
    [SerializeField] float enemySpawnDistance = 0;

    [SerializeField] Transform playerPos;

    public void enemyUpdate() {
        if (nextEnemySpawn >= 1) {
            spawnEnemyRnd();
            nextEnemySpawn = 0;
        } else {
            nextEnemySpawn += Time.deltaTime * enemySpawnRate;
        } 
        foreach (enemy e in enemies) e.updateEnemy();
    }

    public void spawnEnemyRnd() {
        Vector3 rndPos = Random.insideUnitCircle.normalized;
        rndPos*=enemySpawnDistance;
        spawnEnemy(playerPos.position + rndPos);
    }
    public void spawnEnemy(Vector3 aPos) {
        enemy enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        enemy e = Instantiate(enemyPrefab, transform);
        enemies.Add(e);
        e.transform.position = aPos;
        e.onKilled.AddListener(enemyKilled);
    }

    public void enemyKilled(enemy anEnemy) {
        anEnemy.onKilled.RemoveAllListeners();
        if (enemies.Contains(anEnemy)) enemies.Remove(anEnemy);
        ExpManager.Instance.addExp(anEnemy.expAmount);
        Destroy(anEnemy.gameObject);
    }
}