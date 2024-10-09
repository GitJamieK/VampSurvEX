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
    [SerializeField] playerUpdate playerUpdate;

    public void enemyUpdate() {
        if (nextEnemySpawn >= 1) {
            spawnEnemyRnd();
            nextEnemySpawn = 0;
        } else {
            nextEnemySpawn += Time.deltaTime * enemySpawnRate;
        } 
        foreach (enemy e in enemies) {
            if (playerUpdate.curLevel == 5 && !e.hasIncreasedStats) {
                Debug.Log("eMaxHealth and eDamage updated");
                e.eMaxHealth += 2;
                e.eDamage += 2;
                e.hasIncreasedStats = true;
            }
            if (playerUpdate.curLevel == 10 && !e.hasIncreasedStats) {
                Debug.Log("eMaxHealth and eDamage updated");
                e.eMaxHealth += 3;
                e.eDamage += 3;
                e.hasIncreasedStats = true;
            }
        }
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