using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public int coins = 100;
    public int enemiesRemaining;
    public int life = 10;
    public int stage = 1;
    public int initialNumberOfEnemies = 10;
    private EnemySpawner enemySpawner;

    void Start() {
        gameManager = this;
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
        gameManager.enemiesRemaining -= 1;
        HUD.textEnemies.text = "Enemies: " + gameManager.enemiesRemaining;

        // next stage
        if (gameManager.enemiesRemaining == 0) {
            gameManager.stage += 1;
            GameManager.AddCoins(100);
            HUD.textStage.text = "Stage: " + gameManager.stage;
            HUD.buttonStart.gameObject.SetActive(true);
            HUD.textEnemies.gameObject.SetActive(false);
            HUD.DisplayMessage("Stage " + gameManager.stage + " complete!");
            SFX.PlaySound(SFX.sfx.levelUp);
        }
    }

    public static void EnemyAttacked() {
        gameManager.life -= 1;
        HUD.textLife.text = "Life: " + gameManager.life;

        // game over
        if (gameManager.life == 0) {
            SFX.PlaySound(SFX.sfx.gameOver);
            HUD.panelGameOver.SetActive(true);
        }
    }

    public static void AddCoins(int coins) {
        gameManager.coins += coins;
        HUD.textCoins.text = "Coins: " + gameManager.coins;
    }

    public static void ChargeCoins(int coins) {
        AddCoins(-coins);
    }

    public void Quit() {
        Application.LoadLevel("Menu");
    }

}
