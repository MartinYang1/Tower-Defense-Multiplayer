using UnityEngine;

public class SpawnTower : MonoBehaviour
{
    public GameObject towerPrefab; // Reference to your tower prefab

    public void SpawnTowerAtButtonPosition(Vector3 buttonPosition)
    {
        // Spawn the tower at the original sidebar button position
        Instantiate(towerPrefab, buttonPosition, Quaternion.identity);
    }
}
