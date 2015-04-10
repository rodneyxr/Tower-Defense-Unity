using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int coins = 100;
    private int stage = 1;

    void Start() {
        HUD.textCoins.text = "Coins: " + coins;
        HUD.textStage.text = "Stage: " + stage;
    }

    public void StartStage() {
        print("TODO: StartStage"); // TODO: Start Stage
    }

}
