using UnityEngine;
using System.Collections;

public class LaserTower : MonoBehaviour {

    public GameObject barrel;

    public float damage = 20f;
    public float range = 30f;
    public float delay = 2f;
    public int cost = 15;

    private bool canAttack = true;

    private SphereCollider sphereCollider;
    private LineRenderer lr;

    private ArrayList targets = new ArrayList();

    void Start() {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
        lr.SetPosition(0, transform.position);
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
    }

    void Update() {
        if (canAttack && targets.Count > 0) {
            Enemy target = ((Enemy)targets[0]);
            if (target == null) {
                targets.Remove(target);
                return;
            }
            StartCoroutine(Attack(target));
        }
    }

    public void setRange(float range) {
        this.range = range;
        sphereCollider.radius = range;
    }

    IEnumerator Attack(Enemy target) {
        canAttack = false;
        lr.SetPosition(1, target.transform.position);
        lr.enabled = true;
        target.Damage(damage);
        yield return new WaitForSeconds(.15f);
        lr.enabled = false;

        yield return new WaitForSeconds(delay);
        canAttack = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag != "Enemy") return;
        targets.Add(other.gameObject.GetComponent<Enemy>());
    }

    void OnTriggerExit(Collider other) {
        if (other.tag != "Enemy") return;
        targets.Remove(other.gameObject.GetComponent<Enemy>());
    }

}
