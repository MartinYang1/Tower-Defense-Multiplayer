using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesReference;

    [SerializeField]
    private float spawnDelay, scalingFactor;  // scaling factor is the difficulty percentage increase per round
    [SerializeField]
    private int numEnemies;

    private IEnumerator SpawnRabbit() {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < numEnemies; ++i){
            GameObject enemy = Instantiate(enemiesReference[0]);
            enemy.SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
        yield return new WaitForSeconds(5);
        StartNewRound();
    }

    void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {
        StartNewRound();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartNewRound() {
        StartCoroutine(SpawnRabbit());
        spawnDelay /= scalingFactor * 1.5f;
        numEnemies = (int)(numEnemies * (2 * scalingFactor));
    }
}
