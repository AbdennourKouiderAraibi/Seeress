using UnityEngine;

public class Enemy : MonoBehaviour {
    public float moveSpeed = 3f;
    public int damageAmount = 10;

    public int maxHealth = 3;
    private int currentHealth;

    private Transform player;

    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        // Add death animation/effects here
        Destroy(gameObject);
    }

    private void Update() {
        if (player != null) {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (player != null) {
                player.TakeDamage(damageAmount);
            }
        }
    }
}
