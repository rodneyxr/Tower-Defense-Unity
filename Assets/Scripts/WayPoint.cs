using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    public WayPoint next;

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            if (next == null) {
                Destroy(enemy.gameObject);
                GameManager.EnemyKilled();
                GameManager.EnemyAttacked();
            } else {
                enemy.target = next.transform;
            }
        }
    }
}
