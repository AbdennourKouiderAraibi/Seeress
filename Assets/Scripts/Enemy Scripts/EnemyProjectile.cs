using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float speed = 5f;
    public int damage = 1;
    private Vector2 direction;

    public void SetDirection(Vector2 dir) {
        direction = dir.normalized;
    }

    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            PlayerBehaviour player = other.GetComponent<PlayerBehaviour>();
            if (player != null) {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}

