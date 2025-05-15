using UnityEngine;

public class EnemyShooter : MonoBehaviour {
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    public float fireRange = 10f;
    private Transform player;
    private float fireTimer;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() {
        if (player == null) return;

        fireTimer += Time.deltaTime;
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= fireRange && fireTimer >= fireRate) {
            FireProjectile();
            fireTimer = 0f;
        }
    }

    void FireProjectile() {
        Vector2 direction = (player.position - transform.position).normalized;
        GameObject proj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        proj.GetComponent<EnemyProjectile>().SetDirection(direction);
    }
}

