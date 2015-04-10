using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {

    public GameObject[] towers;
    private int selectedTower = -1;

    void Start() {

    }

    public GameObject SetupTower(GameObject towerBase) {
        if (selectedTower == -1) {
            HUD.DisplayMessage("No tower is selected.");
            return null;
        }

        return Instantiate(towers[selectedTower], new Vector3(towerBase.transform.position.x, towers[selectedTower].transform.position.y, towerBase.transform.position.z), Quaternion.identity) as GameObject;

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
