using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;
    public float speed = 1f;
    public float health = 100f;

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    public void Damage(float damage) {
        health -= damage;

        // death
        if (health <= 0) {
            health = 0;
            GameManager.AddCoins(10);
            GameManager.EnemyKilled();
            Destroy(gameObject);
        }
    }

}
