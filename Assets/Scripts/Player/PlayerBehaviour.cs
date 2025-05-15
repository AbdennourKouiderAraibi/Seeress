using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    [SerializeField] private float attackRange = 1f;
    [SerializeField] private int attackDamage = 1;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private Transform attackPoint;

    // Crop data
    [SerializeField] private GameObject[] seedPrefabs;
    [SerializeField] private float interactRange = 1.5f;
    [SerializeField] private LayerMask soilLayer;
    [SerializeField] private LayerMask plantLayer;

    public int maxHealth = 100;
    private int currentHealth;

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E)) {
            if (!TryHarvestPlantNearby()) {
                TryPlantSeedNearby();
            }
        }

        if (Input.GetMouseButtonDown(1)) { // Right-click
            Attack();
        }
    }

    private void FixedUpdate() {
        rb.linearVelocity = movement.normalized * moveSpeed;
    }

    void Attack() {
        // Show animation/sound if you have any
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies) {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    // Handles the player's different interactions
    private void TryPlantSeedNearby() {
        Collider2D[] nearbySoils = Physics2D.OverlapCircleAll(transform.position, interactRange, soilLayer);

        foreach (Collider2D soilCollider in nearbySoils) {
            SoilTile soil = soilCollider.GetComponent<SoilTile>();
            if (soil != null && !soil.IsOccupied) {
                int selectedSeedIndex = Random.Range(0, seedPrefabs.Length);
                soil.PlantSeed(seedPrefabs[selectedSeedIndex]);
                return;
            }
        }
    }

    private bool TryHarvestPlantNearby() {
        Collider2D[] nearbyPlants = Physics2D.OverlapCircleAll(transform.position, interactRange, plantLayer);

        foreach (Collider2D col in nearbyPlants) {
            Plant plant = col.GetComponent<Plant>();
            if (plant != null && plant.IsFullyGrown) {
                SoilTile soil = col.GetComponentInParent<SoilTile>();
                plant.Harvest();
                if (soil != null) {
                    soil.ClearSoil();
                }
                return true; // Harvested one plant, exit
            }
        }
        return false; // No harvestable plant found
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(this.gameObject);
    }
}
