using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform target;
    private NavMeshAgent nav;

    void Start() {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update() {
        nav.SetDestination(target.position);
    }
}
