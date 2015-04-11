using UnityEngine;
using System.Collections;

public class LaserTower : MonoBehaviour {

    public GameObject barrel;

    public float damage = 20f;
    public float range = 30f;
    public float delay = 2f;
    public int cost = 15;
    public int[] upgradeCost = { 25, 50, 75 };
    public int grade = -1;

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
        cost = upgradeCost[0];
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

    public void Upgrade() {
        GameManager.ChargeCoins(cost);
        grade += 1;
        if (CanUpgrade)
            cost = upgradeCost[grade + 1];
        SFX.PlaySound(SFX.sfx.drill);
        damage *= 1.7f;
        range *= 1.8f;
        delay *= .75f;
        HUD.DisplayMessage("Tower upgraded to grade " + (grade + 2) + "!");
    }

    public bool CanUpgrade {
        get { return grade < upgradeCost.Length - 1; }
    }

    IEnumerator Attack(Enemy target) {
        canAttack = false;
        SFX.PlaySound(SFX.sfx.laserShot);
        barrel.transform.LookAt(target.transform);
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
