using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float seconds = 3f;
    private float timer;
    private bool timerActive = true;

    // Start is called before the first frame update
    void Start()
    {
        timer = seconds;
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (enemyPrefab != null)
        {
            // Instantiate a new enemy at a random position
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
            Instantiate(enemyPrefab, randomSpawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Enemy prefab not assigned in the inspector.");
        }
    }
    void Update()
    {
        if (timerActive)
        {
            // Count down the timer
            timer -= Time.deltaTime;

            // Check if the timer has reached zero
            if (timer <= 0f)
            {
                SpawnEnemy();

                timer = seconds;
            }
        }
    }
}
