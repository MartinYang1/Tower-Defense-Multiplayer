using UnityEngine;

public class TowerButton : MonoBehaviour
{
    public int towerIndex;
    public TowerPlacement towerPlacement;

    private void OnMouseDown()
    {
        if (towerPlacement != null)
        {
            towerPlacement.SelectTower(towerIndex);
            
        }
        else
        {
            
        }
    }
}
