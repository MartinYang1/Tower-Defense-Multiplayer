using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesReference;
    private List<GameObject> enemies;

    private IEnumerator SpawnRabbit() {
        while (true) {
            GameObject enemy = Instantiate(enemiesReference[0]);
            enemy.SetActive(true);
            enemies.Add(enemy);
            yield return new WaitForSeconds(3);
        }
    }

    void Awake() {
        enemies = new List<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRabbit());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
