using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [System.Serializable]
    public class TowerType
    {
        public GameObject prefab;
        public int cost;
    }

    public TowerType[] towerTypes;
    private GameObject selectedTower;

    // Reference to the LevelManager
    public LevelManager levelManager;

    // Flag indicating whether placement mode is active
    private bool isPlacementModeActive = false;

    // UI Prefabs
    public GameObject UIPrefab1;
    public GameObject UIPrefab2;

    // Reference to the instantiated UI object
    private GameObject currentUIPrefab;

    // Adjustable offset for UI prefab position
    public Vector3 uiPrefabOffset = new Vector3(-2, 2, 0); // Adjust as needed

    void Start()
    {
        // Ensure that the LevelManager is assigned to the TowerPlacement script
        if (levelManager == null)
        {
            Debug.LogError("LevelManager is not assigned to the TowerPlacement script!");
        }

        // Instantiate the default UI prefab
        SetUIPrefab();
    }

    void Update()
    {
        // Check for the toggle button (left mouse button over an object with the "Button" tag)
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Button"))
            {
                // Toggle placement mode
                isPlacementModeActive = !isPlacementModeActive;

                // Reset selected tower when exiting placement mode
                if (!isPlacementModeActive)
                {
                    selectedTower = null;
                }

                // Update the UI prefab based on the tower selection mode
                SetUIPrefab();
            }
        }

        // Check if placement mode is active
        if (isPlacementModeActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                TryPlaceTower();
            }
        }
    }

    void TryPlaceTower()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Adjust the distance from the camera if needed
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Collider2D hitCollider = Physics2D.OverlapPoint(worldPosition);

        if (hitCollider != null && hitCollider.CompareTag("PlacementTile"))
        {
            // Find the TowerType corresponding to the selectedTower
            TowerType towerType = FindTowerType(selectedTower);

            // Check if the player can afford to place the tower
            if (towerType != null && levelManager.CanAfford(towerType.cost))
            {
                // Deduct the tower cost from the currency
                levelManager.SpendCurrency(towerType.cost);

                // Place the tower in the middle of the tile
                PlaceTower(hitCollider.transform.position, towerType.prefab);

                // Delete the placement tile
                Destroy(hitCollider.gameObject);
            }
            else
            {
                Debug.Log("Not enough currency to place this tower.");
            }
        }
    }

    void PlaceTower(Vector3 position, GameObject towerPrefab)
    {
        if (towerPrefab != null)
        {
            Instantiate(towerPrefab, position, Quaternion.identity);
            Debug.Log("Placed Tower: " + towerPrefab.name + " at " + position);

            // Update the UI prefab based on the tower selection mode
            SetUIPrefab();
        }
        else
        {
            Debug.LogWarning("No tower selected!");
        }
    }

    public void SelectTower(int towerIndex)
    {
        if (IsValidTowerIndex(towerIndex))
        {
            selectedTower = towerTypes[towerIndex].prefab;
            Debug.Log("Selected Tower: " + selectedTower.name);

            // Update the UI prefab based on the tower selection mode
            SetUIPrefab();
        }
    }

    bool IsValidTowerIndex(int towerIndex)
    {
        if (towerIndex < 0 || towerIndex >= towerTypes.Length)
        {
            Debug.LogWarning("Invalid tower index: " + towerIndex);
            return false;
        }

        return true;
    }

    TowerType FindTowerType(GameObject towerPrefab)
    {
        return System.Array.Find(towerTypes, type => type.prefab == towerPrefab);
    }

    void SetUIPrefab()
    {
        // Destroy the current UI prefab if it exists
        if (currentUIPrefab != null)
        {
            Destroy(currentUIPrefab);
        }

        // Calculate the position with the adjustable offset
        Vector3 uiPrefabPosition = uiPrefabOffset;

        // Instantiate the appropriate UI prefab at the calculated position
        if (selectedTower == towerTypes[0].prefab)
        {
            currentUIPrefab = Instantiate(UIPrefab1, uiPrefabPosition, Quaternion.identity);
        }
        else if (selectedTower == towerTypes[1].prefab)
        {
            currentUIPrefab = Instantiate(UIPrefab2, uiPrefabPosition, Quaternion.identity);
        }
    }
}
