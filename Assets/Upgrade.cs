using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public int fireRateUpgradeCost = 10;
    public int damageUpgradeCost = 15;

    public float fireRateMultiplier = 0.8f;
    public float damageMultiplier = 1.2f;
    public float cost_scale = 2f;

    public float displayDuration = 2f;

    private TowerLevelText towerLevelText; // Reference to the TowerLevelText script

    private void Start()
    {
        // Find and store the TowerLevelText script on the tower
        towerLevelText = GetComponent<TowerLevelText>();

        // Display the initial upgrade cost upon tower placement
        UpdateUpgradeCostDisplay();
    }

    private void Update()
    {
        CheckForClick();
        towerLevelText.upgradeCost = fireRateUpgradeCost + damageUpgradeCost;
    }
    private void UpdateUpgradeCostDisplay()
    {
        if (towerLevelText != null)
        {
            towerLevelText.upgradeCost = fireRateUpgradeCost + damageUpgradeCost;
            towerLevelText.ShowLevelText(displayDuration);
        }
    }


    private void CheckForClick()
    {
        if (Input.GetMouseButtonDown(0)) // Assuming left mouse button for the click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // The tower has been clicked
                UpgradeTower();
            }
        }
    }

    private void UpgradeTower()
    {
        // Check if the player can afford the upgrade
        if (LevelManager.main.CanAfford(fireRateUpgradeCost + damageUpgradeCost))
        {
            // Deduct the cost from the player's currency before upgrading
            LevelManager.main.SpendCurrency(fireRateUpgradeCost + damageUpgradeCost);

            // Upgrade fire rate
            UpgradeFireRate();

            // Upgrade damage
            UpgradeDamage();

            // Display tower level text only if the upgrade was successful
            ShowLevelText();

            // Update the upgrade cost display in TowerLevelText script
            UpdateUpgradeCostDisplay();
        }
        else
        {
            Debug.Log("Not enough currency to upgrade the tower. Required: " +
                      (LevelManager.main.CanAfford(fireRateUpgradeCost) ? 0 : fireRateUpgradeCost) + " currency for fire rate upgrade, " +
                      (LevelManager.main.CanAfford(damageUpgradeCost) ? 0 : damageUpgradeCost) + " currency for damage upgrade");
        }
    }

    private void UpgradeFireRate()
    {
        Transform shootPoint = transform.Find("ShootPoint"); // Assuming the child object with RotateAndShoot is named "ShootPoint"
        if (shootPoint != null)
        {
            RotateAndShoot turretScript = shootPoint.GetComponent<RotateAndShoot>();

            if (turretScript != null)
            {
                float newCooldown = turretScript.shootingCooldown * fireRateMultiplier;
                turretScript.shootingCooldown = Mathf.Max(newCooldown, 0.1f); // Ensure cooldown doesn't go below a certain value
                fireRateUpgradeCost = Mathf.RoundToInt(fireRateUpgradeCost * cost_scale);
            }
        }
    }

    private void UpgradeDamage()
    {
        Transform shootPoint = transform.Find("ShootPoint"); // Assuming the child object with RotateAndShoot is named "ShootPoint"
        if (shootPoint != null)
        {
            RotateAndShoot turretScript = shootPoint.GetComponent<RotateAndShoot>();

            if (turretScript != null)
            {
                float newDamage = turretScript.turretDamage * damageMultiplier;
                turretScript.turretDamage = newDamage;
                damageUpgradeCost = Mathf.RoundToInt(damageUpgradeCost * cost_scale);
            }
        }
    }

    private void ShowLevelText()
    {


        // Check if the TowerLevelText script is attached
        TowerLevelText towerLevelText = GetComponent<TowerLevelText>();
        if (towerLevelText != null)
        {
            // Display tower level text
            towerLevelText.ShowLevelText(displayDuration);
        }
    }
}

