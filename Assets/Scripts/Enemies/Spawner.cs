using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemiesReference;

    private IEnumerator SpawnRabbit() {
        while (true) {
            GameObject enemy = Instantiate(enemiesReference[0]);
            enemy.SetActive(true);
            yield return new WaitForSeconds(3);
        }
    }


    void Awake() {
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
