using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {

    public GameObject[] towers;
    private int selectedTower = -1;

    public GameObject SetupTower(GameObject towerBase) {
        if (selectedTower == -1) {
            HUD.DisplayMessage("No tower is selected.");
            return null;
        }

        int cost = towers[selectedTower].GetComponent<LaserTower>().cost;

        if (GameManager.coins >= cost) {
            GameManager.ChargeCoins(cost);
            return Instantiate(towers[selectedTower], new Vector3(towerBase.transform.position.x, towers[selectedTower].transform.position.y, towerBase.transform.position.z), Quaternion.identity) as GameObject;
        } else {
            HUD.DisplayMessage("You need at least " + cost + " coins to build this tower!");
            return null;
        }

    }

    public int SelectedTower {
        get { return selectedTower; }
        set {
            if (value >= 0 && value < towers.Length)
                selectedTower = value;
            else
                selectedTower = -1;
        }
    }

}
