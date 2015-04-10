using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static int coins = 100;
    public static int enemiesRemaining;
    public static int life = 10;
    public static int stage = 1;
    public int initialNumberOfEnemies = 10;
    private EnemySpawner enemySpawner;

    void Start() {
        enemySpawner = GetComponent<EnemySpawner>();
        HUD.textCoins.text = "Coins: " + coins;
        HUD.textStage.text = "Stage: " + stage;
        HUD.textLife.text = "Life: " + life;
    }

    public void StartStage() {
        enemiesRemaining = (int)(initialNumberOfEnemies * Mathf.Pow(1.5f, (float)stage - 1));
        HUD.textEnemies.text = "Enemies: " + enemiesRemaining;
        enemySpawner.SpawnEnemies(enemiesRemaining);
        HUD.buttonStart.gameObject.SetActive(false);
        HUD.textEnemies.gameObject.SetActive(true);
    }

    public static void EnemyKilled() {
        enemiesRemaining -= 1;
        HUD.textEnemies.text = "Enemies: " + enemiesRemaining;

        // next stage
        if (enemiesRemaining == 0) {
            stage += 1;
            GameManager.AddCoins(100);
            HUD.textStage.text = "Stage: " + stage;
            HUD.buttonStart.gameObject.SetActive(true);
            HUD.textEnemies.gameObject.SetActive(false);
        }
    }

    public static void EnemyAttacked() {
        life -= 1;
        HUD.textLife.text = "Life: " + life;

        // game over
        if (life == 0) {
            HUD.panelGameOver.SetActive(true);
        }
    }

    public static void AddCoins(int coins) {
        GameManager.coins += coins;
        HUD.textCoins.text = "Coins: " + GameManager.coins;
    }

    public static void ChargeCoins(int coins) {
        AddCoins(-coins);
    }

    public void Quit() {
        Application.Quit();
    }

}
