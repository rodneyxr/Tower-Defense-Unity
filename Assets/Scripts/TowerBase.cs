using UnityEngine;
using System.Collections;

public class TowerBase : MonoBehaviour {
    private static TowerManager towerManager;

    public Material selectedMaterial;
    private Material defaultMaterial;
    private Renderer rend;
    private LaserTower tower;

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
            GameObject tObject = towerManager.SetupTower(gameObject);
            if (tObject != null) {
                tower = tObject.GetComponent<LaserTower>();
            }
        } else {
            if (GameManager.gameManager.coins < tower.cost) {
                SFX.PlaySound(SFX.sfx.error);
                HUD.DisplayMessage("You need at least " + tower.cost + " coins to upgrade this tower!");
            } else if (!tower.CanUpgrade) {
                SFX.PlaySound(SFX.sfx.error);
                HUD.DisplayMessage("This tower is already maxed out!");
            } else {
                tower.Upgrade();
            }
        }
    }

}
