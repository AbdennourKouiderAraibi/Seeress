using UnityEngine;

public class Health : MonoBehaviour {
    public int maxHealth = 100;
    private int currentHealth;

    private void Start() {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;

        if (currentHealth < 0) {
            Die();
        }
    }

    public int GetHealth() {
        return currentHealth;
    }

    private void Die() {
        Destroy(gameObject);
    }
}
