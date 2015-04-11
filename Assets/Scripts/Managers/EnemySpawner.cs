using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    public Enemy[] enemies;
    public WayPoint spawnPoint;
    public float spawnDelay = 3f;
    private int enemiesLeft;

    IEnumerator SpawnEnemies() {
        while (enemiesLeft > 0) {
            Spawn();
            enemiesLeft -= 1;
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnEnemies(int numberOfEnemies) {
        enemiesLeft = numberOfEnemies;
        spawnDelay -= .2f;
        if (spawnDelay < 1) spawnDelay = 1f;
        StartCoroutine(SpawnEnemies());
    }

    private void Spawn() {
        Enemy enemy = Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoint.transform.position, spawnPoint.transform.rotation) as Enemy;
        enemy.target = spawnPoint.next.transform;
        enemy.speed = enemy.speed * Mathf.Pow(1.2f, (float)GameManager.gameManager.stage - 1);
    }
}
