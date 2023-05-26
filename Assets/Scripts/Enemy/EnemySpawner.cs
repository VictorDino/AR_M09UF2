using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int[] enemiesPerWave; 
    public float spawnDelay = 2f; 
    public float waveDelay = 5f;

    public Transform[] spawnPoints; 

    private int currentWave; 
    private int enemiesAlive; 

    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        for (currentWave = 0; currentWave < enemiesPerWave.Length; currentWave++)
        {
            for (int i = 0; i < enemiesPerWave[currentWave]; i++)
            {
                SpawnEnemy();
                enemiesAlive++;
                yield return new WaitForSeconds(spawnDelay);
            }

            while (enemiesAlive > 0)
            {
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(waveDelay);
        }
        Debug.Log("Has ganado! Todas las oleadas de enemigos han sido derrotadas!");
        SceneManager.LoadScene("Menu");
    }

    void SpawnEnemy()
    {
        Transform chosenSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefab, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
    }

    public void EnemyDefeated()
    {
        enemiesAlive--;
    }
}
