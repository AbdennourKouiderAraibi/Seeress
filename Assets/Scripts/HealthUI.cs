using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {
    [SerializeField] private Image healthBarFill;
    [SerializeField] private PlayerBehaviour player;

    private void Update() {
        healthBarFill.fillAmount = (float)player.CurrentHealth / player.MaxHealth;
    }
}
