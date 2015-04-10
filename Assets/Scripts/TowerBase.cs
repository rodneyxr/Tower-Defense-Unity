using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {
    private static TowerManager towerManager;

    public Material selectedMaterial;
    private Material defaultMaterial;
    private Renderer rend;
    private GameObject tower;

    void Start() {
        towerManager = GameObject.Find("_Main").GetComponent<TowerManager>();
        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;
    }

    void OnMouseEnter() {
        rend.material = selectedMaterial;
    }

    void OnMouseExit() {
        rend.material = defaultMaterial;
    }

    void OnMouseDown() {
        if (tower == null) {
            tower = towerManager.SetupTower(gameObject);
        } else {
            HUD.DisplayMessage("There is already a tower setup at this base!");
        }
    }

}
