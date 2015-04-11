using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;
    public Animator anim;
    private GameObject bloodSplat;
    public float speed = 1f;
    public float health = 100f;

    void Start() {
        bloodSplat = Resources.Load("Prefabs/BloodSplat/BloodSplat") as GameObject;
        anim.SetFloat("Speed", speed);
    }

    void Update() {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    public void Damage(float damage) {
        health -= damage;
        Instantiate(bloodSplat, transform.position, Quaternion.identity);

        // death
        if (health <= 0) {
            health = 0;
            GameManager.AddCoins(10);
            GameManager.EnemyKilled();
            Destroy(gameObject);
        }
    }

}
