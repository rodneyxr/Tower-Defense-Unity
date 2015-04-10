using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;
    public float speed = 1f;


    void Start() {
    }

    void Update() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

}
