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

    // rabbit - 0, cow - 1, chicken - 2
    private bool[] enemiesSpawned = {false, false, false};   // if all enemies of that type i.e cow have spawned in each round

    public delegate void RoundOver();
    public static event RoundOver roundOverInfo;

    private IEnumerator SpawnRabbit() {
        yield return new WaitForSeconds(3);
        for (int i = 0; i < numEnemies; ++i){
            GameObject enemy = Instantiate(enemiesReference[0]);
            enemy.SetActive(true);
            yield return new WaitForSeconds(spawnDelay);
        }
        enemiesSpawned[0] = true;
    }

    void Awake() {
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckRoundOver();
    }

    public void StartNewRound() {
        StartCoroutine(SpawnRabbit());
    }

    // Getters and setters
    public bool[] getEnemiesSpawned() {
        return enemiesSpawned;
    }

    private void CheckRoundOver() {
        // CHANGE THIS LINE LATER
        if (enemiesSpawned[0] && transform.childCount == 0) {
            print("Before " + numEnemies);
            Invoke("EndRound", 3);
            enemiesSpawned[0] = false;
        }

    }

    private void EndRound() {
        spawnDelay /= scalingFactor * 1.5f;
        print("After" + numEnemies);
        numEnemies = (int)(numEnemies * (2 * scalingFactor));
        if (roundOverInfo != null) {}
            roundOverInfo();
    }
}
