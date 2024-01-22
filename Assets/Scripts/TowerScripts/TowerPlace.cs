using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    public GameObject towerPrefab; // Reference to your tower prefab
    public GameObject additionalObjectPrefab; // Reference to the additional object prefab

    public Vector3 spawnOffset = new Vector3(0, 0, 0); // Adjust this vector to set the spawn offset

    public int towerCostPerPlacement = 50; // Tower cost variable that can be set in the inspector

    private bool isPlacementModeActive = false;
    private List<GameObject> placementTiles = new List<GameObject>();

    private GameObject spawnedAdditionalObject; // Reference to the spawned additional object

    private void Start()
    {
        // Populate the list of placement tiles at the start of the game
        GameObject[] tiles = GameObject.FindGameObjectsWithTag("PlacementTile");
        placementTiles.AddRange(tiles);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for simplicity
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                // Check if Tower Button is clicked
                if (hit.collider.CompareTag("TowerButton"))
                {
                    // Toggle placement mode and handle currency
                    TogglePlacementMode();

                    // Spawn or respawn the additional object at the specified location
                    SpawnOrRespawnAdditionalObject();
                }
                // Check if Placement Tile is clicked
                else if (hit.collider.CompareTag("PlacementTile") && isPlacementModeActive)
                {
                    // Place tower at the clicked Placement Tile and handle currency
                    PlaceTower(hit.collider.gameObject);
                }
            }
        }
    }

    private void TogglePlacementMode()
    {
        // Get the LevelManager instance
        LevelManager gameLevelManager = LevelManager.main;

        // Check if there's enough currency to toggle placement mode
        int toggleCost = 0; // Add any additional cost for toggling placement mode
        if (gameLevelManager.CanAfford(toggleCost) || !isPlacementModeActive)
        {
            isPlacementModeActive = !isPlacementModeActive;

            // Despawn the additional object if placement mode is not active
            if (!isPlacementModeActive && spawnedAdditionalObject != null)
            {
                Destroy(spawnedAdditionalObject);
            }

            // Spend the currency for toggling placement mode
            gameLevelManager.SpendCurrency(toggleCost);

            // You can add additional logic here if needed, such as changing UI to indicate placement mode
        }
        else
        {
            Debug.Log("You do not have enough to toggle placement mode");
        }
    }

    private void PlaceTower(GameObject placementTile)
    {
        // Get the LevelManager instance
        LevelManager gameLevelManager = LevelManager.main;

        // Check if there's enough currency to place the tower
        if (gameLevelManager.CanAfford(towerCostPerPlacement))
        {
            // Instantiate a new tower at the position of the clicked Placement Tile
            Instantiate(towerPrefab, placementTile.transform.position, Quaternion.identity);

            // Remove the Placement Tile from the list
            placementTiles.Remove(placementTile);

            // Destroy the Placement Tile
            Destroy(placementTile);

            // Spend the currency for placing the tower
            gameLevelManager.SpendCurrency(towerCostPerPlacement);
        }
        else
        {
            Debug.Log("You do not have enough to place this tower");
        }
    }

    private void SpawnOrRespawnAdditionalObject()
    {
        // Despawn the additional object if it exists
        if (spawnedAdditionalObject != null)
        {
            Destroy(spawnedAdditionalObject);
        }

        // Spawn a new object at the specified offset from the top right of the screen if placement mode is active
        if (isPlacementModeActive)
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)) + spawnOffset;
            spawnPosition.z = 0; // Ensure the object is at the correct Z position
            spawnedAdditionalObject = Instantiate(additionalObjectPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
