using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

    public WayPoint next;
    public bool start;
    public bool end;

    void Start() {

    }

    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Enemy")) {
            Enemy enemy = other.GetComponent<Enemy>();
            if (end) {
                Destroy(enemy.gameObject);
            } else {
                enemy.target = next.transform;
            }
        }
    }
}
