using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Image healthBar;

    private void Start() {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    void UpdateHealthBar() {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }
}
